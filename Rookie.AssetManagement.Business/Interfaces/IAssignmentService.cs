using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.AssignmentDtos;

namespace Rookie.AssetManagement.Business.Interfaces
{
    public interface IAssignmentService
    {
        Task<PagedResponseModel<AssignmentDTO>> GetByPageAsync(
            AssignmentQueryCriteria assignmentQueryCriteria,
            CancellationToken cancellationToken,
            int userid);
        Task<AssignmentDTO> RespondToAssigment(AssignmentResponseDTO dto, int userId);

        Task<AssignmentDTO> CreateAssignment(
            AssignmentCreateDTO assignmentCreateRequest, 
            int userid
            );

        Task<AssignmentDTO> UpdateAsync(
            int id,
            AssignmentCreateDTO assignmentRequest,
            int userid
            );

        Task<PagedResponseModel<AssignmentDTO>> GetByPageForHomeAsync(
            AssignmentQueryCriteria assignmentQueryCriteria,
            CancellationToken cancellationToken,
            int userid);
        Task<bool> DeleteAssignment(int id);
    }
}
