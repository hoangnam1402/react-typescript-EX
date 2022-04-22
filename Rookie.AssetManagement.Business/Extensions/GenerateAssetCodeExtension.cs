using System;
using System.Linq;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.DataAccessor.Entities;

namespace Rookie.AssetManagement.Business.Extensions
{
    public static class GenerateAssetCodeExtension
    {
        public static string GenerateAssetCode(IBaseRepository<Asset> assetRepository, IBaseRepository<AssetCategory> assetCategoryRepository, int categoryID)
        {
            var asset = assetRepository.Entities.Where(x => x.CategoryID == categoryID).OrderBy(x => x.Id).LastOrDefault();
            int newCode = 1;
            if (asset != null)
            {
                var code = assetRepository.Entities.Where(s => s.Id == asset.Id).FirstOrDefault().Code.Substring(2);
                newCode = Convert.ToInt32(code) + 1;
            }
            string shortNameCategory = assetCategoryRepository.Entities.Where(x => x.Id == categoryID).FirstOrDefault().ShortName;
            string assetCode = shortNameCategory + String.Format("{0:D6}", newCode);
            return assetCode;

        }
    }
}
