using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetManagement.Facade.Interface;
using AssetManagement.DTO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssetManagement.Controllers
{
    [Route("api/Asset")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        // GET: /<controller>/
        private readonly IAssetFacade _assetFacade;
        public AssetController(IAssetFacade assetFacade)
        {
            _assetFacade = assetFacade;
        }
        [HttpPost]
        [Route("addAsset")]
        public async Task<IActionResult> AddAsset(AssetDTO assetDTO)
        {
            bool success = false;
            try
            {
                success = await _assetFacade.AddAsset(assetDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return base.Ok(success);
        }

        [Route("editAsset")]
        [HttpPut]
        public async Task<IActionResult> EditAsset(AssetDTO assetDTO)
        {
            bool status = false;

            try
            {
                if (assetDTO != null && assetDTO.Id > 0)
                {
                    assetDTO.UpdatedDate = DateTime.Now;
                    status = await _assetFacade.EditAsset(assetDTO);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return base.Ok(status);

        }

        [HttpGet]
        [Route("getAssetById/{id}")]
        public async Task<IActionResult> GetAssetById(int id)
        {
            AssetDTO assetDTO;
            try
            {
                assetDTO = await _assetFacade.GetAssetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return base.Ok(assetDTO);
        }

        [HttpGet]
        [Route("getAssetByName/{name}")]
        public async Task<IActionResult> GetAsssetByName(string name)
        {
            AssetDTO assetDTO;
            try
            {
                assetDTO = await _assetFacade.GetAsssetByName(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return base.Ok(assetDTO);
        }


        [Route("deleteAssetById/{id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteAssetById(int id)
        {
            bool status = false;

            try
            {
                status = await _assetFacade.DeleteAssetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return base.Ok(status);

        }

        [HttpGet]
        [Route("getAsset")]
        public async Task<IActionResult> GetAsset()
        {
            List<AssetDTO> assetDTOs;
            try
            {
                assetDTOs = await _assetFacade.GetAsset();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return base.Ok(assetDTOs);
        }

    }
}
