using Order.Model;
using Order.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Services.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<OrdersDTO>> GetOrders();
        Task<OrdersDTO> GetOrderById(int id);
        Task Add(OrdersDTO order);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, OrdersDTO order);
    }
}
