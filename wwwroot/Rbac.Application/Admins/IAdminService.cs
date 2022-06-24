using Rbac.Application.Admins.Dto;
using Rbac.Application.Roles.Dto;
using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Application.Admins
{
    public interface IAdminService : IBaseService<Admin, AdminDto>
    {
        ResultDto Register(AdminDto dto);
    }
}
