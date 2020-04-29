using AssetManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.BLL.Interface
{
    public interface IAssetBLL
    {
        Task<bool> AddAsset(Asset asset);

        Task<bool> EditAsset(Asset asset);

        Task<Asset> GetAssetById(int id);

        Task<List<Asset>> GetAsset();

        Task<Asset> GetAsssetByName(string name);

        Task<bool> DeleteAssetById(int id);

        Task<bool> AssignAsset(CustomerAsset customerAsset);
    }
}
