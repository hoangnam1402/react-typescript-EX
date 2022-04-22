using Rookie.AssetManagement.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Business.Interfaces
{
    public interface IAssetCategoryService
    {
        Task<IList<AssetCategoryDTO>> GetAll();
    }
}
