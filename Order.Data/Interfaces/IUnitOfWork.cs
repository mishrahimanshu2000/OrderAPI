using Order.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IOrdersRepository Orders { get; }
        IProductRepository Products { get; }
        IOrderDetailRepository OrderDetails { get; }
        Task SaveAsync();
    }
}
