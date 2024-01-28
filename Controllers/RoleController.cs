using API_Electronic.Services;
using API_Electronic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Electronic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService) 
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            try
            {
                return Ok(await _roleService.GetAllRole());
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            try
            {
                return Ok(await _roleService.GetRoleById(id));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            try
            {
                var roleId = await _roleService.Create(model);
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(new { RoleId = roleId });
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, RoleModel model)
        {
            try
            {
                await _roleService.Update(id, model);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(new { Message = "Role update successfully." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                await _roleService.Delete(id);
                return Ok(new { Message = "Role deleted successfully." });
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
