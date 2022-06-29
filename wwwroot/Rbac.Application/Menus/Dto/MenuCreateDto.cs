using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Application
{
    public class MenuCreateDto
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string LinkUrl { get; set; }
        public int ParentId { get; set; }
    }

    public class MenuListDto : MenuCreateDto
    {
        public bool IsShow { get; set; }
    }
}
