using API_Electronic.Services;
using API_Electronic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API_Electronic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            return Ok(await _userService.GetAllUser());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                return Ok(await _userService.GetUserById(id));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserModel user)
        {
            try
            {
                var userId = await _userService.Create(user);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(new { UserId = userId });
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            try
            {
                await _userService.Delete(id);
                return Ok(new { Message = "User deleted successfully." });
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserById(int id, UserModel model)
        {
            try
            {
                await _userService.Update(id, model);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(new { Message = "User update successfully." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
