using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Model;

namespace AssetManagement.BLL.Interface
{
    public interface ICustomerBLL
    {
        Task<bool> AddCustomer(Customer customer);

        Task<bool> EditCustomer(Customer customer);

        Task<Customer> GetCustomerById(int id);


        Task<List<Customer>> GetCustomer();

        Task<Customer> GetCustomerByName(string name);

        Task<bool> DeleteCustomerById(int id);
        Task<bool> AssignAsset(CustomerAsset customerAsset);
    }
}
