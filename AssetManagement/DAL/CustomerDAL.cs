using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Model;
using AssetManagement.DAL.Interface;
using AssetManagement.Model.DBContext;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.DAL
{
    public class CustomerDAL : ICustomerDAL
    {
        private readonly AssetDBContext _assetDBContext;

        public CustomerDAL(AssetDBContext assetDBContext)
        {
            _assetDBContext = assetDBContext;
        }
        public async Task<bool> AddCustomer(Customer customer)
        {
            try
            {
                if (customer != null)
                {
                    customer.CreatedDate = DateTime.Now;
                    await _assetDBContext.Customers.AddRangeAsync(customer);
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

        public async Task<bool> DeleteCustomerById(int id)
        {
            var deleteCustomer = await _assetDBContext.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (deleteCustomer != null)
            {
                _assetDBContext.Customers.Remove(deleteCustomer);
                await _assetDBContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> EditCustomer(Customer customer)
        {
            var modifyCustomer = await _assetDBContext.Customers.FirstOrDefaultAsync(x => x.Id == customer.Id);

            modifyCustomer.Contactnumber = customer.Contactnumber;
            modifyCustomer.UpdatedDate = customer.UpdatedDate;
            modifyCustomer.UpdatedBy = customer.UpdatedBy;
            await _assetDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _assetDBContext.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Customer>> GetCustomer()
        {
           return await _assetDBContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByName(string name)
        {
            return await _assetDBContext.Customers.Where(x => x.Customername.Contains(name)).FirstOrDefaultAsync();
        }

        public async Task<bool> AssignAsset(CustomerAsset customerAsset)
        {
            try
            {
                if (customerAsset != null)
                {
                    int countOfCustomer = _assetDBContext.CustomerAssets.Where(x => x.CustomerId == customerAsset.CustomerId).Count();
                    if (countOfCustomer < 3)
                    {
                        await _assetDBContext.CustomerAssets.AddRangeAsync(customerAsset);
                        await _assetDBContext.SaveChangesAsync();
                        return true;
                    }

                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
