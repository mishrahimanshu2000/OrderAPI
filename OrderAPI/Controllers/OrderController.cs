using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Model;
using Order.Services.DTOs;
using Order.Services.Interface;

namespace OrderAPI.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetailDTO>>> Get()
        {
            var orderDetails = await _orderService.GetOrders();
            return Ok(orderDetails);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersDTO>> GetById(int id)
        {
            return await _orderService.GetOrderById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrdersDTO order)
        {
            await _orderService.Add(order);
            return Ok("Order Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, OrdersDTO order)
        {
            bool res = await _orderService.Update(id, order);
            return res == true ? Ok("Order Updated Successfully")
                : BadRequest("please make correct request");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool res = await _orderService.Delete(id);
            return res == true ? Ok("Order Deleted Successfully")
                : NotFound("Order Does not exist with " + id + " id");
        }
    }
}
