using Rbac.Entity;
using Rbac.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rbac.Application
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public List<MenuDto> GetAll()
        {
            var list = menuRepository.GetAll();

            List<MenuDto> menus = new List<MenuDto>();

            var menu = list.Where(m => m.ParentId == 0).Select(m => new MenuDto
            {
                MenuId = m.MenuId,
                MenuName = m.MenuName,
                LinkUrl = m.LinkUrl
            }).ToList();

            GetNodes(menu);

            return menu;
        }

        public void GetNodes(List<MenuDto> menus)
        {
            var list = menuRepository.GetAll();

            foreach (var item in menus)
            {
                var _list = list.Where(s => s.ParentId == item.MenuId).Select(m => new MenuDto
                {
                    MenuId = m.MenuId,
                    MenuName = m.MenuName,
                    LinkUrl = m.LinkUrl,
                });

                item.children.AddRange(_list);
            }
        }
    }
}
