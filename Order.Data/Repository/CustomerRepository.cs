using Order.Data.Data;
using Order.Data.Interfaces;
using Order.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Data.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository 
    {
        private ApplicationDbContext _dbContext;
        public CustomerRepository(ApplicationDbContext context)
            : base(context)
        {
            _dbContext = context;
        }

        public IList<ProductByCustomer> Getproduct(int id)
        {
            var query =
               from c in _dbContext.Customers
               join o in _dbContext.Orders on c.CustomerId equals o.CustomerId
               join od in _dbContext.OrderDetails on o.OrderId equals od.OrderId
               join p in _dbContext.Products on od.ProductId equals p.ProductId
               where c.CustomerId == id
               select new ProductByCustomer
               {
                   CustomerId = c.CustomerId,
                   OrderId = o.OrderId,
                   OrderDetailId = od.OrderDetailId,
                   ProductId = od.ProductId,
                   ProductName = p.ProductName,
                   ProductCode = p.ProductCode,
                   Price = p.ProductPrice
               };
            return query.ToList();

        }
    }
}
