﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Application.Roles.Dto
{
    public class RoleDto
    {
        ///<summary>
        ///角色Id
        ///</summary>
        public int RoleId { get; set; }

        ///<summary>
        ///角色名称
        ///</summary>
        public string RoleName { get; set; }
    }
}
