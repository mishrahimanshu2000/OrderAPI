using Order.Data.Interfaces;
using Order.Model;
using Order.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _unitOfWork.Customers.GetAllAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _unitOfWork.Customers.GetAsync(c => c.CustomerId == id);
        }

        public async Task Add(Customer customer)
        {
            _unitOfWork.Customers.Add(customer);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> Delete(int id)
        {
            Customer customer = await GetCustomerById(id);
            if (customer == null)
            {
                return false;
            }
            _unitOfWork.Customers.Delete(customer);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> Update(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return false;
            }
            _unitOfWork.Customers.Update(customer);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
