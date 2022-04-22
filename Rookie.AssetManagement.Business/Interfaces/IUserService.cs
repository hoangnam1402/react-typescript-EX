using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
namespace Rookie.AssetManagement.Business.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> RegisterUser(UserCreateDto assetRequest);
        Task<PagedResponseModel<UserDto>> GetByPageAsync(UserQueryCriteriaDto assetQueryCriteria, CancellationToken cancellationToken, int userid);
        Task<UserDto> GetById(int id);
        Task<UserDto> UpdateAsync(int id, UserCreateDto userRequest);
    }
}
