using DataAccess.Context;
using DataAccess.Repositories.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        CarRepository _carRepository;
        CarGalleryRepository _galleryRepository;
        public CarsController(AppDbContext context)
        {
            _carRepository = new CarRepository(context);
            _galleryRepository = new CarGalleryRepository(context);
        }
        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
                return Ok(_carRepository.GetActives());
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
                return Ok(_carRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add")]
        public IActionResult Add(Car car)
        {
            try
            {
                _carRepository.Add(car);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update")]
        public IActionResult Update(Car car)
        {
            try
            {
                _carRepository.Update(car);
                _carRepository.Activate(car.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Car car)
        {
            try
            {
                _carRepository.Remove(car);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ListCarsAndGaleries")]
        public IActionResult ListCarsAndGaleries()
        {
            try
            {
                List<CarGallery> galeries = _galleryRepository.GetActives();
                List<Car> cars = _carRepository.GetActives();
                return Ok(_carRepository.GetCarsAndGaleries(galeries, cars));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
