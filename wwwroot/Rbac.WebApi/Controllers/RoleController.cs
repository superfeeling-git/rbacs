using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rbac.Application.Roles;
using Rbac.Application.Roles.Dto;

namespace Rbac.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService role;

        public RoleController(IRoleService role)
        {
            this.role = role;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(role.GetList());
        }

        [HttpPost]
        public IActionResult Post(RoleDto dto)
        {
            return Ok(role.Create(dto));
        }
    }
}
