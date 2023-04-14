using Order.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Services.Interface
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetail>> GetOrderDetails();
        Task<OrderDetail> GetOrderDetailById(int id);
        Task Add(OrderDetail orderDetail);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, OrderDetail orderDetail);
    }
}
