using Order.Model;
using Order.Services.DTOs;
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
        Task<IEnumerable<CustomerDTO>> GetCustomers();
        Task<CustomerDTO> GetCustomerById(int id);
        Task Add(CustomerDTO customer);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, CustomerDTO customer);

        IEnumerable<ProductByCustomer> GetProductsCustomer(int id);
    }
}
