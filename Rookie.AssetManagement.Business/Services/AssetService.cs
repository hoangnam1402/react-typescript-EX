using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EnsureThat;
using Microsoft.EntityFrameworkCore;
using Rookie.AssetManagement.Business.Extensions;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.AssetDtos;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using Rookie.AssetManagement.DataAccessor.Entities;
using Rookie.AssetManagement.DataAccessor.Enums;

namespace Rookie.AssetManagement.Business.Services
{
    public class AssetService : IAssetService
    {
        private readonly IBaseRepository<Asset> _assetRepository;
        private readonly IBaseRepository<AssetCategory> _assetCategoryRepository;
        private readonly IBaseRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public AssetService(
            IBaseRepository<Asset> assetRepository,
            IMapper mapper,
            IBaseRepository<User> userRepository,
            IBaseRepository<AssetCategory> assetcateRepository)
        {
            _assetRepository = assetRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _assetCategoryRepository = assetcateRepository;
        }

        public async Task<PagedResponseModel<AssetDTO>> GetByPageAsync(
         AssetQueryCriteria assetQueryCriteria,
         CancellationToken cancellationToken,
         int userid)
        {
            var location = _userRepository.Entities
            .Where(x => x.Id == userid)
            .Select(x => x.Location)
            .FirstOrDefault();

            var assetQuery = AssetFilter(
                _assetRepository.Entities.AsQueryable(),
                assetQueryCriteria);

            var assets = await assetQuery
                .AsNoTracking()
                .Where(x => x.Location == location)
                .Include("Category")
                .PaginateAsync(
                    assetQueryCriteria,
                    cancellationToken);

            var dtos = _mapper.Map<IList<AssetDTO>>(assets.Items);

            return new PagedResponseModel<AssetDTO>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = dtos
            };
        }

        public async Task<AssetDTO> CreateAsset(AssetCreateDTO assetCreateRequest, int userid)
        {
            Ensure.Any.IsNotNull(assetCreateRequest);

            var location = _userRepository.Entities
            .Where(x => x.Id == userid)
            .Select(x => x.Location)
            .FirstOrDefault();

            var code = GenerateAssetCodeExtension.GenerateAssetCode(
                                            _assetRepository,
                                            _assetCategoryRepository,
                                            assetCreateRequest.CategoryID);

            var newAsset = _mapper.Map<Asset>(assetCreateRequest);
            newAsset.Code = code;
            newAsset.LastUpdate = DateTime.Now;
            newAsset.Location = location;

            var result = await _assetRepository.Add(newAsset);
            if (result != null)
            {
                return _mapper.Map<AssetDTO>(newAsset);
            }
            return null;
        }

        public async Task<AssetDTO> UpdateAsset(int id, AssetUpdateDTO assetUpdateRequest)
        {
            var asset = await _assetRepository.Entities
                .Include(s=>s.Category)
                .FirstOrDefaultAsync(x=>x.Id==id);

            if (asset == null)
            {
                throw new NotFoundException("Not Found!");
            }

            asset = _mapper.Map<AssetUpdateDTO, Asset>(assetUpdateRequest, asset);

            var assetUpdated = await _assetRepository.Update(asset);

            var assetUpdatedDTO = _mapper.Map<AssetDTO>(assetUpdated);

            return assetUpdatedDTO;
        } 
        public async Task<bool> DeleteAsset(int id)
        {
            var asset = await _assetRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);

            if (asset == null)
            {
                throw new NotFoundException("Not Found!");
            }
            if (asset.State == AssetStateEnum.Assigned)
            {
                throw new ErrorException("Cannot delete when state asset is assigned");
            }
            if (asset.IsDeleted == true)
            {
                throw new ErrorException("Asset has been deleted before");
            }
            asset.IsDeleted = true;

            var assetDelete = await _assetRepository.Update(asset);

            return assetDelete!=null;
        }

        #region Private Method
        private IQueryable<Asset> AssetFilter(
            IQueryable<Asset> assetQuery,
            AssetQueryCriteria assetQueryCriteria)
        {
            if (!String.IsNullOrEmpty(assetQueryCriteria.Search))
            {
                assetQuery = assetQuery.Where(b =>
                    b.Name.Contains(assetQueryCriteria.Search) || 
                    b.Code.Contains(assetQueryCriteria.Search) 
                    );
            }

            if (assetQueryCriteria.Category != null &&
                assetQueryCriteria.Category.Count() > 0)
            {
                assetQuery = assetQuery.Where(x =>
                    assetQueryCriteria.Category.Any(t => t == (int)x.CategoryID));
            }
            if (assetQueryCriteria.State != null &&
             assetQueryCriteria.State.Count() > 0)
            {
                assetQuery = assetQuery.Where(x =>
                    assetQueryCriteria.State.Any(t => t == (int)x.State));
            }
            if (assetQueryCriteria.SortColumn == "state")
            {
                assetQuery = assetQueryCriteria.SortOrder == SortOrderEnumDto.Accsending 
                    ?assetQuery.OrderBy(p =>
                    p.State == AssetStateEnum.Available ? "Available" :
                    p.State == AssetStateEnum.NotAvailable ? "NotAvailable" :
                    p.State == AssetStateEnum.Assigned ? "Assigned" :
                    p.State == AssetStateEnum.WaitingForRecycling ? "WaitingForRecycling" :
                    p.State == AssetStateEnum.Recycled ? "Recycled" :
                    "ZZZ"
                    )
                    :assetQuery.OrderByDescending(p =>
                    p.State == AssetStateEnum.Available ? "Available" :
                    p.State == AssetStateEnum.NotAvailable ? "NotAvailable" :
                    p.State == AssetStateEnum.Assigned ? "Assigned" :
                    p.State == AssetStateEnum.WaitingForRecycling ? "WaitingForRecycling" :
                    p.State == AssetStateEnum.Recycled ? "Recycled" :
                    "ZZZ");
                assetQueryCriteria.SortColumn = null;
            }
            //not showing deleted asset
            assetQuery = assetQuery.Where(x=>x.IsDeleted==false);

            return assetQuery;
        }

        #endregion
    }
}
