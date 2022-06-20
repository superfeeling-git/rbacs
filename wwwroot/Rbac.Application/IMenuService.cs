using Rbac.Entity;
using System.Collections.Generic;

namespace Rbac.Application
{
    public interface IMenuService
    {
        List<Menu> GetAll();
    }
}