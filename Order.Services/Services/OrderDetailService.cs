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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Add(OrderDetail orderDetail)
        {
            _unitOfWork.OrderDetails.Add(orderDetail);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var orderDetail = await GetOrderDetailById(id);
            if (orderDetail == null)
            {
                return false;
            }
            _unitOfWork.OrderDetails.Delete(orderDetail);
            return true;

        }

        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            return await _unitOfWork.OrderDetails.GetAsync(item => item.OrderDetailId == id);

        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetails()
        {
            return await _unitOfWork.OrderDetails.GetAllAsync();
        }

        public async Task<bool> Update(int id, OrderDetail orderDetail)
        {
            if(id != orderDetail.OrderDetailId)
            {
                return false;
            }
            _unitOfWork.OrderDetails.Update(orderDetail);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
