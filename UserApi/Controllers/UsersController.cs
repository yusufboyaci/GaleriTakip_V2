using DataAccess.Context;
using DataAccess.Repositories.Concrete;
using DataAccess.ViewModels;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserRepository _userRepository;
        public UsersController(AppDbContext context)
        {
            _userRepository= new UserRepository(context);
        }
        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
                List<User> users = _userRepository.GetActives();
                return Ok(users);
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
                return Ok(_userRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add")]
        public IActionResult Add(User user) 
        {
            try
            {
                _userRepository.Add(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update")]
        public IActionResult Update(User user) 
        {
            try
            {
                _userRepository.Update(user);
                _userRepository.Activate(user.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(User user) 
        {
            try
            {
                _userRepository.Remove(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Login")]
        public IActionResult Login(UserLoginVM user)
        {
            try
            {
                bool result = _userRepository.CheckCredential(user.Username, user.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
