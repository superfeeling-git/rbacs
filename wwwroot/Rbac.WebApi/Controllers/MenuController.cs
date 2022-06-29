using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rbac.Application;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Rbac.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]//标签，特性 Attribute
    public class MenuController : ControllerBase
    {
        private readonly IMenuService menuService;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="menuService"></param>
        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return new JsonResult(menuService.GetAll());
        }

        [HttpGet]        
        public IActionResult GetCascaderAll()
        {
            return new JsonResult(menuService.GetCascaderAll());
        }

        [HttpPost]
        public IActionResult Create(MenuCreateDto dto)
        {
            return Ok(menuService.Create(dto));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetMenuList()
        {
            return new JsonResult(menuService.GetMenu());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return Ok(menuService.Delete(id));
        }
    }
}
