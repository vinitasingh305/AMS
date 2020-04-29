using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.DTO;

namespace AssetManagement.Facade.Interface
{
    public interface ICustomerFacade
    {
        Task<bool> AddCustomer(CustomerDTO customer);

        Task<bool> EditCustomer(CustomerDTO customer);

        Task<CustomerDTO> GetCustomerById(int id);


        Task<List<CustomerDTO>> GetCustomer();

        Task<CustomerDTO> GetCustomerByName(string name);

        Task<bool> DeleteCustomerById(int id);

        Task<bool> AssignAsset(CustomerAssetDTO customerAssetDTO);
    }
}
