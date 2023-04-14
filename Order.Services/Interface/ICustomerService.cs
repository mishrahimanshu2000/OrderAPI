using Order.Model;
using Order.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Services.Interface
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int id);
        Task Add(Customer customer);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, Customer customer);
    }
}
