using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rbac.Application;

namespace Rbac.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
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
    }
}
