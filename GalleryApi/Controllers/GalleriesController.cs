using DataAccess.Context;
using DataAccess.Repositories.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GalleryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleriesController : ControllerBase
    {
        CarGalleryRepository db;
        public GalleriesController(AppDbContext context)
        {
            db = new CarGalleryRepository(context);
        }
        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
                return Ok(db.GetActives());
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
                return Ok(db.GetById(id));
            }
            catch
            {
                return BadRequest("Sistem de bir hata meydana geldi");
            }
        }
        [HttpPost("Add")]
        public IActionResult Add(CarGallery gallery)
        {
            try
            {
                db.Add(gallery);
                return NoContent();
            }
            catch
            {
                return BadRequest("Sistem de bir hata meydana geldi");
            }
        }
        [HttpPut("Update")]
        public IActionResult Update(CarGallery gallery)
        {
            try
            {
                db.Update(gallery);
                db.Activate(gallery.Id);
                return NoContent();
            }
            catch
            {
                return BadRequest("Sistem de bir hata meydana geldi");
            }
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(CarGallery gallery)
        {
            try
            {
                db.Remove(gallery);
                return NoContent();
            }
            catch
            {
                return BadRequest("Sistem de bir hata meydana geldi");
            }
        }
    }
}
