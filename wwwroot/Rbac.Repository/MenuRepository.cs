﻿using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rbac.Repository
{
    public class MenuRepository : BaseRepository<Menu, int>, IMenuRepository
    {
        public MenuRepository(RbacDbContext context)
        {
            this.db = context;
        }
    }
}
