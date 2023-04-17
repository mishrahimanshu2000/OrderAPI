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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(OrderDetailDTO orderDetailDTO)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDTO);
            _unitOfWork.OrderDetails.Add(orderDetail);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var orderDetail = await _unitOfWork.OrderDetails.GetAsync(od => od.OrderDetailId == id);
            if (orderDetail == null)
            {
                return false;
            }
            _unitOfWork.OrderDetails.Delete(orderDetail);
            return true;

        }

        public async Task<OrderDetailDTO> GetOrderDetailById(int id)
        {
            var order =  await _unitOfWork.OrderDetails.GetAsync(item => item.OrderDetailId == id);
            return(_mapper.Map<OrderDetailDTO>(order));

        }

        public async Task<IEnumerable<OrderDetailDTO>> GetOrderDetails()
        {
            var orderDetails =  await _unitOfWork.OrderDetails.GetAllAsync();
            var orderDetailDTO = _mapper.Map<IList<OrderDetailDTO>>(orderDetails);
            return orderDetailDTO;
        }

        public async Task<bool> Update(int id, OrderDetailDTO orderDetailDTO)
        {
            if(id != orderDetailDTO.OrderDetailId)
            {
                return false;
            }
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDTO);
            _unitOfWork.OrderDetails.Update(orderDetail);
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
