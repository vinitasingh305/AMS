using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.BLL.Interface;
using AssetManagement.Model;
using AssetManagement.DAL.Interface;
using System.Transactions;
namespace AssetManagement.BLL
{
    public class AssetBLL : IAssetBLL
    {
        private readonly IAssetDAL _assetDAL;

        public AssetBLL(IAssetDAL assetDAL)
        {
            _assetDAL = assetDAL;
        }
        public async Task<bool> AddAsset(Asset asset)
        {
            bool success = false;

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    success = await _assetDAL.AddAsset(asset);
                    scope.Complete();

                }
                catch (Exception)
                {
                    success = false;
                    throw;
                }
            }
            return success;
        }

        public Task<bool> AssignAsset(CustomerAsset customerAsset)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAssetById(int id)
        {
            bool status = false;

            if (id > 0)
                status = await _assetDAL.DeleteAssetById(id);

            return status;
        }

        public async Task<bool> EditAsset(Asset asset)
        {
            bool status = false;

            if (asset != null && asset.Id > 0)
            {
                status = await _assetDAL.EditAsset(asset);
            }
            return status;
        }

        public async Task<List<Asset>> GetAsset()
        {
            return await _assetDAL.GetAsset();
        }

        public async Task<Asset> GetAssetById(int id)
        {
            return await _assetDAL.GetAssetById(id);
        }

        public async Task<Asset> GetAsssetByName(string name)
        {
            return await _assetDAL.GetAsssetByName(name);
        }
    }
}
