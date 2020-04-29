using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Model;

namespace AssetManagement.DAL.Interface
{
   public interface ICustomerDAL
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
