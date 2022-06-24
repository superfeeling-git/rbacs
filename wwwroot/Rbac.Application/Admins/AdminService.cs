using AutoMapper;
using Rbac.Application.Admins.Dto;
using Rbac.Entity;
using Rbac.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Application.Admins
{
    public class AdminService : BaseService<Admin, AdminDto>, IAdminService
    {
        private readonly IAdminRepository AdminRepository;
        private readonly IMapper mapper;

        public AdminService(IAdminRepository AdminRepository, IMapper mapper)
            : base(AdminRepository, mapper)
        {
            this.AdminRepository = AdminRepository;
            this.mapper = mapper;
        }

        public ResultDto Login(LoginDto dto)
        {
            //登录逻辑
            throw new NotImplementedException();
        }

        public ResultDto Register(AdminDto dto)
        {
            if(AdminRepository.GetEntity(m=>m.UserName == dto.UserName.ToLower()) != null)
            {
                return new ResultDto { Code = 1, Msg = "已存在此用户" };
            }

            //密码、注册时间、末次登录时间
            dto.Password = Md5(dto.Password);
            dto.CreateTime = DateTime.Now;
            dto.LastLoginTime = null;

            AdminRepository.Create(mapper.Map<Admin>(dto));

            return new ResultDto { Code = 0, Msg = "注册成功" };
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string Md5(string val)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(val)).Select(x => x.ToString("x2")));
        }
    }
}
