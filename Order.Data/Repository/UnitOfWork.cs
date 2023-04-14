using Order.Data.Data;
using Order.Data.Interfaces;
using Order.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private ICustomerRepository? _customer;
        private IOrderDetailRepository? _orderDetail;
        private IOrdersRepository? _orders;
        private IProductRepository? _product;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IProductRepository Products => _product ??= new ProductRepository(_context);

        public ICustomerRepository Customers => _customer ??= new CustomerRepository(_context);

        public IOrdersRepository Orders => _orders ??= new OrderRepository(_context);

        public IOrderDetailRepository OrderDetails => _orderDetail ??= new OrderDetailRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
