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
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ResultDto Register(AdminDto dto);
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        TokenDto Login(LoginDto dto);
        /// <summary>
        /// 分页记录
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        Tuple<List<AdminListDto>, int> Page(int PageIndex = 1, int PageSize = 10);
    }
}
