using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Model;
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
        public async Task<ActionResult<IEnumerable<OrderDetail>>> Get()
        {
            var orderDetails = await _orderDetailService.GetOrderDetails();
            return Ok(orderDetails);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetail>> GetById(int id)
        {
            return await _orderDetailService.GetOrderDetailById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderDetail orderDetail)
        {
            await _orderDetailService.Add(orderDetail);
            return Ok("Order Detail Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, OrderDetail orderDetail)
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
