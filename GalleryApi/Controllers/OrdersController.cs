using DataAccess.Context;
using DataAccess.Repositories.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GalleryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        OrderRepository _orderRepository;
        public OrdersController(AppDbContext context)
        {
            _orderRepository = new OrderRepository(context);
        }
        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
                return Ok(_orderRepository.GetActives());
            }
            catch
            {
                return BadRequest("Sistem de bir hata meydana geldi");
            }
        }
        [HttpGet("ListUnapprovedOrders")]
        public IActionResult ListUnapprovedOrders()
        {
            try
            {
                return Ok(_orderRepository.ListUnapprovedOrders());
            }
            catch
            {
                return BadRequest("Sistem de bir hata meydana geldi");
            }
        }
        [HttpGet("Get")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_orderRepository.GetById(id));
            }
            catch
            {
                return BadRequest("Sistem de bir hata meydana geldi");
            }
        }
        [HttpPost("Add")]
        public IActionResult Add(Order order)
        {
            try
            {
                _orderRepository.Add(order);
                return NoContent();
            }
            catch
            {
                return BadRequest("Sistem de bir hata meydana geldi");
            }
        }
        [HttpPut("Update")]
        public IActionResult Update(Order order)
        {
            try
            {
                _orderRepository.Update(order);
                _orderRepository.Activate(order.Id);
                return NoContent();
            }
            catch
            {
                return BadRequest("Sistem de bir hata meydana geldi");
            }
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Order order)
        {
            try
            {
                _orderRepository.Remove(order);
                return NoContent();
            }
            catch
            {
                return BadRequest("Sistem de bir hata meydana geldi");
            }
        }
    }
}
