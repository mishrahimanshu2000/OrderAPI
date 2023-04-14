using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Data.Interfaces;
using Order.Model;
using Order.Services.Interface;

namespace OrderAPI.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            var orderDetails = await _customerService.GetCustomers();
            return Ok(orderDetails);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            return await _customerService.GetCustomerById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Customer  customer)
        {
            await _customerService.Add(customer);
            return Ok("Customer Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, Customer customer)
        {
            bool res = await _customerService.Update(id, customer);
            return res == true ? Ok("Customer Updated Successfully")
                : BadRequest("Please make correct request");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool res = await _customerService.Delete(id);
            return res == true ? Ok("Customer Deleted Successfully")
                : NotFound("Customer Does not exist with " + id + " id");
        }
    }
}
