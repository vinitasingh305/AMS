using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.DTO;

namespace AssetManagement.Facade.Interface
{
    public interface IAssetFacade
    {
        Task<bool> AddAsset(AssetDTO asset);

        Task<bool> EditAsset(AssetDTO asset);

        Task<AssetDTO> GetAssetById(int id);

        Task<List<AssetDTO>> GetAsset();

        Task<AssetDTO> GetAsssetByName(string name);

        Task<bool> DeleteAssetById(int id);

        Task<bool> AssignAsset(CustomerAssetDTO customerAssetDTO);
    }
}
