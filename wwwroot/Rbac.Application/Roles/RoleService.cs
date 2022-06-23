using AutoMapper;
using Rbac.Application.Roles.Dto;
using Rbac.Entity;
using Rbac.Repository;
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

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
            :base(roleRepository, mapper)
        {
            this.roleRepository = roleRepository;
        }
    }
}
