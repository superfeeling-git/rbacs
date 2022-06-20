using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rbac.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly RbacDbContext db;

        public MenuRepository(RbacDbContext db)
        {
            this.db = db;
        }

        public List<Menu> GetAll()
        {
            return db.Menus.ToList();
        }
    }
}
