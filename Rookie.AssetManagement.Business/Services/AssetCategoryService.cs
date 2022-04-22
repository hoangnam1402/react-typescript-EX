using AutoMapper;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts.Dtos;
using Rookie.AssetManagement.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Business.Services
{
    public class AssetCategoryService : IAssetCategoryService
    {
        private readonly IBaseRepository<AssetCategory> _assetCategoryRepository;
        private readonly IMapper _mapper;

        public AssetCategoryService(IBaseRepository<AssetCategory> assetCategoryRepository, IMapper mapper)
        {
            _assetCategoryRepository = assetCategoryRepository;
            _mapper = mapper;
        }

        public async Task<IList<AssetCategoryDTO>> GetAll()
        {
            var assets = await _assetCategoryRepository.GetAll();
            var dtos = _mapper.Map<IList<AssetCategoryDTO>>(assets);

            return dtos;
        }

        public async Task<bool> IsCategoryExist(int id)
        {
            var category = _assetCategoryRepository.Entities.Where(q => q.Id == id);
            if (category!=null)
            {
                return true;
            }
            return false;
        }
    }
}
