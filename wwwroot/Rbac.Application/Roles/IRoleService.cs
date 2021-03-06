using Rbac.Application.Roles.Dto;
using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Application.Roles
{
    public interface IRoleService : IBaseService<Role, RoleDto>
    {
        int SavePermission(PermissionDto permission);
        /// <summary>
        /// 根据角色Id查询对应的权限
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        List<MenuRoleDto> GetPermissionByRoleId(int RoleId);
    }
}
