using Rbac.Entity;
using Rbac.Repository;
using System;
using System.Collections.Generic;

namespace Rbac.Application
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }

        public List<Menu> GetAll()
        {
            return menuRepository.GetAll();
        }
    }
}
