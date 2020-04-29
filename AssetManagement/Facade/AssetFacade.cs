using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.DTO;
using AssetManagement.Facade.Interface;
using AssetManagement.BLL.Interface;
using AutoMapper;
using AssetManagement.Model;

namespace AssetManagement.Facade
{
    public class AssetFacade : IAssetFacade
    {

        private readonly IAssetBLL _assetBLL;
        private readonly IMapper _mapper;
        public AssetFacade(IAssetBLL assetBLL, IMapper mapper)
        {
            _assetBLL = assetBLL;
            _mapper = mapper;
        }
        public async Task<bool> AddAsset(AssetDTO assetDTO)
        {
            Asset asset = _mapper.Map<Asset>(assetDTO);
            return await _assetBLL.AddAsset(asset);
        }

        public Task<bool> AssignAsset(CustomerAssetDTO customerAssetDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAssetById(int id)
        {
            return await _assetBLL.DeleteAssetById(id);
        }

        public async Task<bool> EditAsset(AssetDTO assetDTO)
        {
            Asset asset = _mapper.Map<Asset>(assetDTO);
            return await _assetBLL.EditAsset(asset);
        }

        public async Task<List<AssetDTO>> GetAsset()
        {
            List<Asset> assets = await _assetBLL.GetAsset();
            List<AssetDTO> assetDTOs = _mapper.Map<List<AssetDTO>>(assets);
            return assetDTOs;
        }

        public async Task<AssetDTO> GetAssetById(int id)
        {
            Asset asset = await _assetBLL.GetAssetById(id);
            AssetDTO assetDTO = _mapper.Map<AssetDTO>(asset);
            return assetDTO;
        }

        public async Task<AssetDTO> GetAsssetByName(string name)
        {
            Asset asset = await _assetBLL.GetAsssetByName(name);
            AssetDTO assetDTO = _mapper.Map<AssetDTO>(asset);
            return assetDTO;
        }
    }
}
