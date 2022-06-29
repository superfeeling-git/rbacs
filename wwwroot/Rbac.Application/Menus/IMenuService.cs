using Rbac.Entity;
using System.Collections.Generic;

namespace Rbac.Application
{
    public interface IMenuService
    {
        List<MenuDto> GetAll();
        List<CascaderDto> GetCascaderAll();
        int Create(MenuCreateDto dto);
        int Delete(int id);
        List<MenuListDto> GetMenu();
    }
}