using DataAccess.Context;
using DataAccess.Repositories.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        CustomerRepository _customerRepository;
        public CustomersController(AppDbContext context)
        {
            _customerRepository= new CustomerRepository(context);
        }
        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
                List<Customer> list  = _customerRepository.GetActives();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Get")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_customerRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }        
        }
        [HttpPost("Add")]
        public IActionResult Add(Customer customer) 
        {
            try
            {
                _customerRepository.Add(customer);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update")]
        public IActionResult Update(Customer customer) 
        {
            try
            {
                _customerRepository.Update(customer);
                _customerRepository.Activate(customer.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Customer customer)
        {
            try
            {
                _customerRepository.Remove(customer);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
