using AutoMapper;
using Order.Data.Interfaces;
using Order.Data.Repository;
using Order.Model;
using Order.Services.DTOs;
using Order.Services.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDTO>> GetCustomers()
        {
            IEnumerable<Customer> customers = await _unitOfWork.Customers.GetAllAsync();
            var res = _mapper.Map<IList<CustomerDTO>>(customers);
            return res;

        }

        public async Task<CustomerDTO> GetCustomerById(int id)
        {
            var customer = await _unitOfWork.Customers.GetAsync(c => c.CustomerId == id);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task Add(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            _unitOfWork.Customers.Add(customer);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> Delete(int id)
        {
            Customer customer = await _unitOfWork.Customers.GetAsync(c => c.CustomerId == id);
            if (customer == null)
            {
                return false;
            }
            _unitOfWork.Customers.Delete(customer);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> Update(int id, CustomerDTO customerDTO)
        {
            if (id != customerDTO.CustomerId)
            {
                return false;
            }
            var customer = _mapper.Map<Customer>(customerDTO);
            customer.LastUpdate = DateTime.Now;
            _unitOfWork.Customers.Update(customer);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public IEnumerable<ProductByCustomer> GetProductsCustomer(int id)
        {
            var query = _unitOfWork.Customers.Getproduct(id);

            return query.ToList();
                
        }
    }
}
