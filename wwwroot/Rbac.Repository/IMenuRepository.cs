using Rbac.Entity;
using System.Collections.Generic;

namespace Rbac.Repository
{
    public interface IMenuRepository
    {
        List<Menu> GetAll();
        int Create(Menu menu);
    }
}