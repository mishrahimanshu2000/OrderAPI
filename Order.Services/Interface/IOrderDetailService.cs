using Order.Model;
using Order.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Services.Interface
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetailDTO>> GetOrderDetails();
        Task<OrderDetailDTO> GetOrderDetailById(int id);
        Task Add(OrderDetailDTO orderDetail);
        Task<bool> Delete(int id);
        Task<bool> Update(int id, OrderDetailDTO orderDetail);
    }
}
