using Order.Data.Interfaces;
using Order.Model;
using Order.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Orders>> GetOrders()
        {
            return await _unitOfWork.Orders.GetAllAsync();
        }

        public async Task<Orders> GetOrderById(int id)
        {
            return await _unitOfWork.Orders.GetAsync(p => p.OrderId == id);
        }

        public async Task Add(Orders order)
        {
            _unitOfWork.Orders.Add(order);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> Delete(int id)
        {
            Orders order = await GetOrderById(id);
            if (order == null)
            {
                return false;
            }
            _unitOfWork.Orders.Delete(order);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> Update(int id, Orders order)
        {
            if (id != order.OrderId)
            {
                return false;
            }
            _unitOfWork.Orders.Update(order);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
