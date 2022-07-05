using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Repository.AdminRoles
{
    public class AdminRoleRepository : BaseRepository<AdminRole, int>, IAdminRoleRepository
    {
        public AdminRoleRepository(RbacDbContext db)
        {
            this.db = db;
        }
    }
}
