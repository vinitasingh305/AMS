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
    public class CustomerBLL : ICustomerBLL
    {

        private readonly ICustomerDAL _customerDAL;

        public CustomerBLL(ICustomerDAL customerDAL)
        {
            _customerDAL = customerDAL;
        }
        public async Task<bool> AddCustomer(Customer customer)
        {
            bool success = false;

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    success = await _customerDAL.AddCustomer(customer);
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
        public async Task<bool> AssignAsset(CustomerAsset customerAsset)
        {
            bool status = false;

            if (customerAsset != null)
                status = await _customerDAL.AssignAsset(customerAsset);

            return status;
        }

        public async Task<bool> DeleteCustomerById(int id)
        {
            bool status = false;

            if (id > 0)
                status = await _customerDAL.DeleteCustomerById(id);

            return status;
        }

        public async Task<bool> EditCustomer(Customer customer)
        {
            bool status = false;

            if (customer != null && customer.Id > 0)
            {
                status = await _customerDAL.EditCustomer(customer);
            }
            return status;
        }

        public async Task<List<Customer>> GetCustomer()
        {
            return await _customerDAL.GetCustomer();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _customerDAL.GetCustomerById(id);
        }

        public async Task<Customer> GetCustomerByName(string name)
        {
            return await _customerDAL.GetCustomerByName(name);
        }
    }
}
