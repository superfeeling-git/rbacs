using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rbac.Repository
{
    public class AdminRepository : BaseRepository<Admin, int>, IAdminRepository
    {
        public AdminRepository(RbacDbContext context)
        {
            this.db = context;
        }
    }
}
