using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rbac.Application.Roles;
using Rbac.Application.Roles.Dto;
using Rbac.Entity;

namespace Rbac.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : BaseController<IRoleService, Role, RoleDto>
    {
        private readonly IRoleService role;

        public RoleController(IRoleService role) : base(role)
        {
            this.role = role;
        }

        [HttpPost]
        public IActionResult SavePermission(PermissionDto permission)
        {
            role.SavePermission(permission);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetPermissionByRoleId(int RoleId)
        {
            return new JsonResult(role.GetPermissionByRoleId(RoleId));
        }
    }
}
