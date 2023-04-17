using AutoMapper;
using Order.Data.Interfaces;
using Order.Model;
using Order.Services.DTOs;
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
        private readonly IMapper _mapper;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrdersDTO>> GetOrders()
        {
            var orders = await _unitOfWork.Orders.GetAllAsync();
            var OrderDTO = _mapper.Map<IList<OrdersDTO>>(orders);
            return OrderDTO;
        }

        public async Task<OrdersDTO> GetOrderById(int id)
        {
            var order =  await _unitOfWork.Orders.GetAsync(p => p.OrderId == id);
            return(_mapper.Map<OrdersDTO>(order));
        }

        public async Task Add(OrdersDTO orderDTO)
        {
            var order = _mapper.Map<Orders>(orderDTO);
            _unitOfWork.Orders.Add(order);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> Delete(int id)
        {
            Orders order = await _unitOfWork.Orders.GetAsync(o => o.OrderId == id);
            if (order == null)
            {
                return false;
            }
            _unitOfWork.Orders.Delete(order);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<bool> Update(int id, OrdersDTO orderDTO)
        {
            if (id != orderDTO.OrderId)
            {
                return false;
            }
            var order = _mapper.Map<Orders>(orderDTO);
            _unitOfWork.Orders.Update(order);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
