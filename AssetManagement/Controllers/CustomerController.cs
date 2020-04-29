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
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerFacade _customerFacade;
        public CustomerController(ICustomerFacade customerFacade)
        {
            _customerFacade = customerFacade;
        }
        // GET: /<controller>/
        [HttpPost]
        [Route("addCustomer")]
        public async Task<IActionResult> AddCustomer(CustomerDTO customerDTO)
        {
            bool success = false;
            try
            {
                success = await _customerFacade.AddCustomer(customerDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return base.Ok(success);
        }

        [Route("editCustomer")]
        [HttpPut]
        public async Task<IActionResult> EditCustomer(CustomerDTO customerDTO)
        {
            bool status = false;

            try
            {
                if (customerDTO != null && customerDTO.Id > 0)
                {
                    customerDTO.UpdatedDate = DateTime.Now;
                    status = await _customerFacade.EditCustomer(customerDTO);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return base.Ok(status);

        }

        [HttpGet]
        [Route("getCustomerById/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            CustomerDTO customerDTO;
            try
            {
                customerDTO = await _customerFacade.GetCustomerById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return base.Ok(customerDTO);
        }

        [HttpGet]
        [Route("getCustomerByName/{name}")]
        public async Task<IActionResult> GetCustomerByName(string name)
        {
            CustomerDTO customerDTO;
            try
            {
                customerDTO = await _customerFacade.GetCustomerByName(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return base.Ok(customerDTO);
        }


        [Route("deleteCustomerById/{id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteCustomerById(int id)
        {
            bool status = false;

            try
            {
                status = await _customerFacade.DeleteCustomerById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return base.Ok(status);

        }

        [HttpGet]
        [Route("getCustomer")]
        public async Task<IActionResult> GetCustomer()
        {
            List<CustomerDTO> customerDTO;
            try
            {
                customerDTO = await _customerFacade.GetCustomer();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return base.Ok(customerDTO);
        }

        [Route("assignAsset")]
        [HttpPost]
        public async Task<IActionResult> AssignAsset(CustomerAssetDTO customerAssetDTO)
        {
            bool status = false;

            try
            {
                if (customerAssetDTO != null)
                {
                    customerAssetDTO.UpdatedDate = DateTime.Now;
                    status = await _customerFacade.AssignAsset(customerAssetDTO);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return base.Ok(status);

        }
    }
}
