using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.AssetDtos;
using Rookie.AssetManagement.DataAccessor.Entities;

namespace Rookie.AssetManagement.Business.Interfaces
{
    public interface IAssetService
    {
        Task<PagedResponseModel<AssetDTO>> GetByPageAsync(AssetQueryCriteria assetQueryCriteria, CancellationToken cancellationToken, int userid);
        Task<AssetDTO> CreateAsset(AssetCreateDTO assetCreateRequest, int userid);
        Task<AssetDTO> UpdateAsset(int id, AssetUpdateDTO assetUpdateRequest);
        Task<bool> DeleteAsset(int id);
    }
}
