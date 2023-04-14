using Order.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Services.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<Orders>> GetOrders();
        Task<Orders> GetOrderById(int id);
        Task Add(Orders order);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, Orders order);
    }
}
