using DataAccess.Context;
using DataAccess.Repositories.Concrete;
using DataAccess.ViewModels;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
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
                List<Car> cars = _carRepository.GetActives();
                return Ok(cars);
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
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("ListCarsAndGaleries")]
        public IActionResult ListCarsAndGaleries()
        {
            try
            {
                List<CarGallery> galeries = _galleryRepository.GetActives();
                List<Car> cars = _carRepository.GetActives();

                List<TableOfTheCarAndGallery> list = (
                    from g in galeries
                    join c in cars
                    on g.Id equals c.CarGalleryId
                    select new TableOfTheCarAndGallery
                    {
                        Id = c.Id,
                        GalleryName = g.Name,
                        GalleryAddress = g.Address,
                        CarName = c.Name,
                        Price = c.Price,
                        Stock = c.Stock,
                        FilePath = c.FilePath,
                        Description = c.Descripton
                    }
                    ).ToList();
                return Ok(list);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
