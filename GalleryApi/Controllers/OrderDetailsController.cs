using DataAccess.Context;
using DataAccess.Repositories.Concrete;
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

    }
}
