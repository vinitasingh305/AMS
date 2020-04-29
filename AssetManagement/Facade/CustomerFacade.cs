using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Facade.Interface;
using AssetManagement.DTO;
using AssetManagement.BLL.Interface;
using AutoMapper;
using AssetManagement.Model;

namespace AssetManagement.Facade
{
    public class CustomerFacade : ICustomerFacade
    {

        private readonly ICustomerBLL _customerBLL;
        private readonly IMapper _mapper;
        public CustomerFacade(ICustomerBLL customerBLL, IMapper mapper)
        {
            _customerBLL = customerBLL;
            _mapper = mapper;
        }
        public async Task<bool> AddCustomer(CustomerDTO customerDTO)
        {
            Customer customer = _mapper.Map<Customer>(customerDTO);
            return await _customerBLL.AddCustomer(customer);
        }

        public async Task<bool> AssignAsset(CustomerAssetDTO customerAssetDTO)
        {
            CustomerAsset customerAsset = _mapper.Map<CustomerAsset>(customerAssetDTO);
            return await _customerBLL.AssignAsset(customerAsset);
        }

        public async Task<bool> DeleteCustomerById(int id)
        {
            return await _customerBLL.DeleteCustomerById(id);
        }

        public async Task<bool> EditCustomer(CustomerDTO customerDTO)
        {
            Customer customer = _mapper.Map<Customer>(customerDTO);
            return await _customerBLL.EditCustomer(customer);
        }

        public async Task<List<CustomerDTO>> GetCustomer()
        {
            List<Customer> customers =await  _customerBLL.GetCustomer();
            List<CustomerDTO> customerDTO = _mapper.Map<List<CustomerDTO>>(customers);
            return customerDTO;
        }

        public async Task<CustomerDTO> GetCustomerById(int id)
        {
            Customer customer = await _customerBLL.GetCustomerById(id);
            CustomerDTO customerDTO = _mapper.Map<CustomerDTO>(customer);
            return customerDTO;
        }

        public async Task<CustomerDTO> GetCustomerByName(string name)
        {
            Customer customer = await _customerBLL.GetCustomerByName(name);
            CustomerDTO customerDTO = _mapper.Map<CustomerDTO>(customer);
            return customerDTO;
        }
    }
}
