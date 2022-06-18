using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    public class RbacDbContext : DbContext
    {
        public RbacDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
