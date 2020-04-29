using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.DAL.Interface;
using AssetManagement.Model;
using AssetManagement.Model.DBContext;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.DAL
{
    public class AssetDAL : IAssetDAL
    {
        private readonly AssetDBContext _assetDBContext;

        public AssetDAL(AssetDBContext assetDBContext)
        {
            _assetDBContext = assetDBContext;
        }
        public async Task<bool> AddAsset(Asset asset)
        {
            try
            {
                if (asset != null)
                {
                    asset.CreatedDate = DateTime.Now;
                    await _assetDBContext.Assets.AddRangeAsync(asset);
                    await _assetDBContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> AssignAsset(CustomerAsset customerAsset)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAssetById(int id)
        {
            var deleteAsset = await _assetDBContext.Assets.FirstOrDefaultAsync(x => x.Id == id);

            if (deleteAsset != null)
            {
                _assetDBContext.Assets.Remove(deleteAsset);
                await _assetDBContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> EditAsset(Asset asset)
        {
            var modifyAsset = await _assetDBContext.Assets.FirstOrDefaultAsync(x => x.Id == asset.Id);
            if(modifyAsset!=null)
            modifyAsset = asset;
            await _assetDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Asset>> GetAsset()
        {
            return await _assetDBContext.Assets.ToListAsync();
        }

        public async Task<Asset> GetAssetById(int id)
        {
            return await _assetDBContext.Assets.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Asset> GetAsssetByName(string name)
        {
            return await _assetDBContext.Assets.Where(x => x.AssetName.Contains(name)).FirstOrDefaultAsync();
        }
    }
}
