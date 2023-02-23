using DataAccess.Context;
using DataAccess.Repositories.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GalleryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        OrderDetailRepository _orderDetailRepository;
        public OrderDetailsController(AppDbContext context)
        {
            _orderDetailRepository = new OrderDetailRepository(context);
        }
        public IActionResult List()
        {
            try
            {
                return Ok(_orderDetailRepository.GetActives());
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
                return Ok(_orderDetailRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add")]
        public IActionResult Add(OrderDetail orderDetail)
        {
            try
            {
                _orderDetailRepository.Add(orderDetail);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update")]
        public IActionResult Update(OrderDetail orderDetail)
        {
            try
            {
                _orderDetailRepository.Update(orderDetail);
                _orderDetailRepository.Activate(orderDetail.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(OrderDetail orderDetail)
        {
            try
            {
                _orderDetailRepository.Remove(orderDetail);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
