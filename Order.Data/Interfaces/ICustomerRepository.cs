using Order.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Data.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        public IList<ProductByCustomer> Getproduct(int id);
    }
    
}
