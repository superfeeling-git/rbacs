using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Repository.MenuRoles
{
    public class MenuRoleRepository : BaseRepository<MenuRole, int>, IMenuRoleRepository
    {
        private readonly RbacDbContext db1;

        public MenuRoleRepository(RbacDbContext db)
        {
            this.db = db;
            this.db1 = db;
        }
    }
}
