using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EnsureThat;
using Microsoft.EntityFrameworkCore;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.AssignmentDtos;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;

namespace Rookie.AssetManagement.Business.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IBaseRepository<Assignment> _assignmentRepository;
        private readonly IBaseRepository<Asset> _assetRepository;
        private readonly IBaseRepository<AssetCategory> _assetCategoryRepository;
        private readonly IBaseRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public AssignmentService(
            IBaseRepository<Assignment> assignmentRepository,
            IBaseRepository<Asset> assetRepository,
            IMapper mapper,
            IBaseRepository<User> userRepository,
            IBaseRepository<AssetCategory> assetcateRepository)
        {
            _assignmentRepository = assignmentRepository;
            _assetRepository = assetRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _assetCategoryRepository = assetcateRepository;
        }

        public async Task<PagedResponseModel<AssignmentDTO>> GetByPageAsync(
         AssignmentQueryCriteria assignmentQueryCriteria,
         CancellationToken cancellationToken,
         int userid)
        {
            var location = _userRepository.Entities
            .Where(x => x.Id == userid)
            .Select(x => x.Location)
            .FirstOrDefault();

            var assignmentQuery = AssignmentFilter(
                _assignmentRepository.Entities.AsQueryable(),
                assignmentQueryCriteria);

            var assets = await assignmentQuery
                .AsNoTracking()
                .Where(x => x.Location == location)
                .Include("Asset")
                .Include("AssignBy")
                .Include("AssignTo")
                .PaginateAsync(
                    assignmentQueryCriteria,
                    cancellationToken);

            var dtos = _mapper.Map<IList<AssignmentDTO>>(assets.Items);

            return new PagedResponseModel<AssignmentDTO>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = dtos
            };
        }
        public async Task<PagedResponseModel<AssignmentDTO>> GetByPageForHomeAsync(
                 AssignmentQueryCriteria assignmentQueryCriteria,
                 CancellationToken cancellationToken,
                 int userid)
        {
            var location = _userRepository.Entities
            .Where(x => x.Id == userid)
            .Select(x => x.Location)
            .FirstOrDefault();

            var assignmentQuery = AssignmentFilter(
                _assignmentRepository.Entities.AsQueryable(),
                assignmentQueryCriteria);

            var assets = await assignmentQuery
                .AsNoTracking()
                .Where(x => x.Location == location &&
                            x.AssignToID == userid &&
                            x.AssignDate <= DateTime.Now &&
                            (x.State == AssignmentStateEnum.Accepted ||
                            x.State == AssignmentStateEnum.WaitingForAcceptance))
                .Include("Asset.Category")
                .Include("AssignBy")
                .Include("AssignTo")
                .PaginateAsync(
                    assignmentQueryCriteria,
                    cancellationToken);

            var dtos = _mapper.Map<IList<AssignmentDTO>>(assets.Items);

            return new PagedResponseModel<AssignmentDTO>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = dtos
            };
        }

        public async Task<AssignmentDTO> RespondToAssigment(AssignmentResponseDTO dto,int userId)
        {
            var assignment = _assignmentRepository.Entities
                .Where(q => q.Id == dto.AssignmentID)
                .Include("Asset")
                .Include("AssignTo")
                .FirstOrDefault();
            var user = _userRepository.Entities.Where(q => q.Id == userId).FirstOrDefault();
            if (assignment == null)
            {
                throw new NotFoundException("Assignment Not Found!");
            }
            if (user==null)
            {
                throw new NotFoundException("User Not Found!");
            }
            if (user.Id!=assignment.AssignToID)
            {
                throw new ErrorException($"User is not assigned to this assignment!");
            }
            Assignment updatedAssigment;
            if (dto.Response==AssignmentResponseEnum.Accepted)
            {
                assignment.State = AssignmentStateEnum.Accepted;
                assignment.Asset.State = AssetStateEnum.Assigned;
                updatedAssigment = await _assignmentRepository.Update(assignment);
            }
            else
            {
                assignment.State = AssignmentStateEnum.Declined;
                assignment.Asset.State = AssetStateEnum.Available;
                updatedAssigment = await _assignmentRepository.Update(assignment);
            }

            AssignmentDTO assignmentDTO = _mapper.Map<AssignmentDTO>(assignment);
            return assignmentDTO;

        }

        public async Task<AssignmentDTO> CreateAssignment(AssignmentCreateDTO assignmentCreateRequest, int userid)
        {
            if (CheckIsExisted(assignmentCreateRequest))
            {
                throw new ErrorException($"User is assignment in this asset at {assignmentCreateRequest.AssignDate}");
            }

            Ensure.Any.IsNotNull(assignmentCreateRequest);

            var location = _userRepository.Entities
                .Where(x => x.Id == userid)
                .Select(x => x.Location)
                .FirstOrDefault();

            var newAssignment = _mapper.Map<Assignment>(assignmentCreateRequest);

            newAssignment.AssignByID = userid;
            newAssignment.State = AssignmentStateEnum.WaitingForAcceptance;
            newAssignment.Location = location;
            newAssignment.IsDelete = false;

            await _assignmentRepository.Add(newAssignment);
            var result =  _assignmentRepository.Entities.Where(q => q.Id == newAssignment.Id)
                .Include("Asset")
                .Include("AssignBy")
                .Include("AssignTo").FirstOrDefault();
            if (result != null)
            {
                return _mapper.Map<AssignmentDTO>(result);
            }
            return null;
        }

        public async Task<bool> DeleteAssignment(int id)
        {
            var assignment = await _assignmentRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);

            if (assignment == null)
            {
                throw new NotFoundException("Not Found!");
            }
            if (assignment.IsDelete == true)
            {
                throw new ErrorException("Asset has been deleted before");
            }
            assignment.IsDelete = true;

            var assetDelete = await _assignmentRepository.Update(assignment);

            return assignment != null;
        }
        public async Task<AssignmentDTO> UpdateAsync(int id, AssignmentCreateDTO assignmentRequest, int userid)
        {

            var assignment = await _assignmentRepository.Entities.FirstOrDefaultAsync(a => a.Id == id);

            if (assignment == null)
            {
                throw new NotFoundException("Not Found!");
            }

            if (CheckIsExisted(assignmentRequest))
            {
                throw new ErrorException($"User is assignment in this asset at {assignmentRequest.AssignDate}");
            }

            assignment.AssignToID = assignmentRequest.AssignToID;
            assignment.AssetID = assignmentRequest.AssetID;
            assignment.AssignDate = assignmentRequest.AssignDate;
            assignment.Note = assignmentRequest.Note;
            assignment.AssignByID = userid;

            var assignmentUpdated = await _assignmentRepository.Update(assignment);

            var result = _assignmentRepository.Entities.Where(q => q.Id == assignmentUpdated.Id)
                .Include("Asset")
                .Include("AssignBy")
                .Include("AssignTo").FirstOrDefault();

            var assignmentUpdatedDto = _mapper.Map<AssignmentDTO>(result);

            return assignmentUpdatedDto;
        }

        #region Private Method
        private IQueryable<Assignment> AssignmentFilter(
            IQueryable<Assignment> assignmentQuery,
            AssignmentQueryCriteria assignmentQueryCriteria)
        {
            if (!String.IsNullOrEmpty(assignmentQueryCriteria.Search))
            {
                assignmentQuery = assignmentQuery.Where(b =>
                    b.Asset.Name.Contains(assignmentQueryCriteria.Search) ||
                    b.Asset.Code.Contains(assignmentQueryCriteria.Search) ||
                    b.AssignTo.UserName.Contains(assignmentQueryCriteria.Search)
                    );
            }
            if (assignmentQueryCriteria.State != null &&
             assignmentQueryCriteria.State.Count() > 0)
            {
                assignmentQuery = assignmentQuery.Where(x =>
                    assignmentQueryCriteria.State.Any(t => t == (int)x.State));
            }
            if (assignmentQueryCriteria.AssignedDate != DateTime.MinValue)
            {
                assignmentQuery = assignmentQuery.Where(x => x.AssignDate.Date == assignmentQueryCriteria.AssignedDate.Date);
            }
            if (assignmentQueryCriteria.SortColumn == "state")
            {
                assignmentQuery = assignmentQueryCriteria.SortOrder == SortOrderEnumDto.Accsending
                    ? assignmentQuery.OrderBy(p =>
                     p.State == AssignmentStateEnum.WaitingForAcceptance ? "WaitingForAcceptance" :
                     p.State == AssignmentStateEnum.Accepted ? "Accepted" :
                     p.State == AssignmentStateEnum.Declined ? "Declined" :
                     p.State == AssignmentStateEnum.RequestForReturning ? "RequestForReturning" :
                     p.State == AssignmentStateEnum.Returned? "Returned" :
                     "ZZZ"
                    )
                    : assignmentQuery.OrderByDescending(p =>
                     p.State == AssignmentStateEnum.WaitingForAcceptance ? "WaitingForAcceptance" :
                     p.State == AssignmentStateEnum.Accepted ? "Accepted" :
                     p.State == AssignmentStateEnum.Declined ? "Declined" :
                     p.State == AssignmentStateEnum.RequestForReturning ? "RequestForReturning" :
                     p.State == AssignmentStateEnum.Returned ? "Returned" :
                     "ZZZ");
                assignmentQueryCriteria.SortColumn = null;
            }
            if (assignmentQueryCriteria.SortColumn == "name")
            {
                assignmentQuery =
                    assignmentQueryCriteria.SortOrder == SortOrderEnumDto.Accsending ?
                    assignmentQuery.OrderBy(q => q.Asset.Name)
                    :
                    assignmentQuery.OrderByDescending(q => q.Asset.Name);
                assignmentQueryCriteria.SortColumn = null;
            }
            if (assignmentQueryCriteria.SortColumn == "code")
            {
                assignmentQuery =
                    assignmentQueryCriteria.SortOrder == SortOrderEnumDto.Accsending ?
                    assignmentQuery.OrderBy(q => q.Asset.Code)
                    :
                    assignmentQuery.OrderByDescending(q => q.Asset.Name);
                assignmentQueryCriteria.SortColumn = null;
            }
            //not showing deleted 
            assignmentQuery = assignmentQuery.Where(x => x.IsDelete == false);
            return assignmentQuery;
        }

        private bool CheckIsExisted(AssignmentCreateDTO assignmentCreateRequest)
        {
            var checkIsExist = _assignmentRepository.Entities
                .FirstOrDefault(x => x.AssignToID == assignmentCreateRequest.AssignToID
                            && x.AssetID == assignmentCreateRequest.AssetID
                            && x.AssignDate.Date == assignmentCreateRequest.AssignDate.Date);

            if (checkIsExist != null)
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}
