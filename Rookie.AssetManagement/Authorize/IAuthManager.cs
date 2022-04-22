using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Authorize
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(UserLoginDTO userDTO);
        Task<string> CreateToken();
    }
}
