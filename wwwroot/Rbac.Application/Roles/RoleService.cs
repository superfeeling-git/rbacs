using AutoMapper;
using Rbac.Application.Roles.Dto;
using Rbac.Entity;
using Rbac.Repository;
using Rbac.Repository.MenuRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Application.Roles
{
    public class RoleService : BaseService<Role,RoleDto>, IRoleService
    {
        private readonly IRoleRepository roleRepository;
        private readonly IMenuRoleRepository menuRoleRepository;
        private readonly IMapper mapper;

        public RoleService
            (
            IRoleRepository roleRepository, 
            IMenuRoleRepository menuRoleRepository, 
            IMapper mapper
            )
            :base(roleRepository, mapper)
        {
            this.roleRepository = roleRepository;
            this.menuRoleRepository = menuRoleRepository;
            this.mapper = mapper;
        }

        public int SavePermission(PermissionDto permission)
        {
            //删除
            menuRoleRepository.Delete(m => m.RoleId == permission.RoleId);

            var ids = permission.MenuId.Select(m => new MenuRole { MenuId = m, RoleId = permission.RoleId }).ToList();

            return menuRoleRepository.BulkCreate(ids);
        }

        public List<MenuRoleDto> GetPermissionByRoleId(int RoleId)
        {
            return mapper.Map<List<MenuRoleDto>>(menuRoleRepository.GetQuery().Where(m => m.RoleId == RoleId).ToList());
        }
    }
}
