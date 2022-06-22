using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Application
{
    public class CascaderDto
    {
        public int value { get; set; }
        public string label { get; set; }
        public List<CascaderDto> children { get; set; } = new List<CascaderDto>();
    }
}
