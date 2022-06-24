﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Application
{
    public class ResultDto
    {
        /// <summary>
        /// >0表示出错，=0成功
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string Msg { get; set; }
    }
}
