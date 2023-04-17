using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Services.DTOs;
using Order.Services.Interface;

namespace OrderAPI.Controllers
{
    [Route("api/orderDetails")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            this._orderDetailService = orderDetailService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetailDTO>>> Get()
        {
            var orderDetails = await _orderDetailService.GetOrderDetails();
            return Ok(orderDetails);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailDTO>> GetById(int id)
        {
            return await _orderDetailService.GetOrderDetailById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderDetailDTO orderDetail)
        {
            await _orderDetailService.Add(orderDetail);
            return Ok("Order Detail Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, OrderDetailDTO orderDetail)
        {
            bool res = await _orderDetailService.Update(id, orderDetail);
            return res == true ? Ok("Order Detail Updated Successfully")
                : BadRequest("please make correct request");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool res = await _orderDetailService.Delete(id);
            return res == true ? Ok("Order Detail Deleted Successfully")
                : NotFound("Order Detail Does not exist with " + id + " id");
        }
    }

}
