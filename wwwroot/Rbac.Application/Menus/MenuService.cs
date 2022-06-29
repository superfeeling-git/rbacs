using Rbac.Entity;
using Rbac.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Rbac.Application
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository menuRepository;
        private readonly IMapper mapper;

        public MenuService(IMenuRepository menuRepository,IMapper mapper)
        {
            this.menuRepository = menuRepository;
            this.mapper = mapper;
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

        public List<MenuListDto> GetMenu()
        {
            return mapper.Map<List<MenuListDto>>(menuRepository.GetAll());
        }

        /// <summary>
        /// 递归--终止条件
        /// </summary>
        /// <param name="menus"></param>
        private void GetNodes(List<MenuDto> menus)
        {
            var list = menuRepository.GetAll();

            foreach (var item in menus)
            {
                var _list = list.Where(s => s.ParentId == item.MenuId).Select(m => new MenuDto
                {
                    MenuId = m.MenuId,
                    MenuName = m.MenuName,
                    LinkUrl = m.LinkUrl
                }).ToList();

                item.children.AddRange(_list);

                GetNodes(_list);
            }
        }

        public int Delete(int id)
        {
            return menuRepository.Delete(id);
        }

        public List<CascaderDto> GetCascaderAll()
        {
            var list = menuRepository.GetAll();

            List<CascaderDto> menus = new List<CascaderDto>();

            var menu = list.Where(m => m.ParentId == 0).Select(m => new CascaderDto
            {
                value = m.MenuId,
                label = m.MenuName
            }).ToList();

            GetCascaderNodes(menu);

            return menu;
        }

        private void GetCascaderNodes(List<CascaderDto> menus)
        {
            var list = menuRepository.GetAll();

            foreach (var item in menus)
            {
                var _list = list.Where(s => s.ParentId == item.value).Select(m => new CascaderDto
                {
                    value = m.MenuId,
                    label = m.MenuName
                }).ToList();

                item.children.AddRange(_list);

                GetCascaderNodes(_list);
            }
        }

        public int Create(MenuCreateDto dto)
        {
            return menuRepository.Create(mapper.Map<Menu>(dto));
        }
    }
}
