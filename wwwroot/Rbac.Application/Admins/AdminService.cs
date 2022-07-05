﻿using AutoMapper;
using IdentityModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Rbac.Application.Admins.Dto;
using Rbac.Entity;
using Rbac.Repository;
using Rbac.Repository.AdminRoles;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Application.Admins
{
    public class AdminService : BaseService<Admin, AdminDto>, IAdminService
    {
        private readonly IAdminRepository AdminRepository;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IAdminRoleRepository adminRoleRepository;

        public AdminService(
            IAdminRepository AdminRepository,
            IMapper mapper, IConfiguration configuration,
            IAdminRoleRepository adminRoleRepository
            )
            : base(AdminRepository, mapper)
        {
            this.AdminRepository = AdminRepository;
            this.mapper = mapper;
            this.configuration = configuration;
            this.adminRoleRepository = adminRoleRepository;
        }

        public TokenDto Login(LoginDto dto)
        {
            var admin = AdminRepository.GetEntity(m => m.UserName == dto.UserName.Trim());
            if (admin == null)
            {
                return new TokenDto { Code = 1, Msg = "没有此用户" };
            }
            if (admin.Password.ToLower() != Md5(dto.Password.Trim().ToLower()))
            {
                return new TokenDto { Code = 2, Msg = "密码错误" };
            }

            //生成Token令牌
            IList<Claim> claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Id, dto.UserName)
            };

            //JWT密钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:key"]));

            //算法，签名证书
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //过期时间
            DateTime expires = DateTime.UtcNow.AddHours(10);


            //Payload负载
            var token = new JwtSecurityToken(
                issuer: configuration["JwtConfig:Issuer"], //发布者、颁发者
                audience: configuration["JwtConfig:Audience"],  //令牌接收者
                claims: claims, //自定义声明信息
                notBefore: DateTime.UtcNow,  //创建时间
                expires: expires,   //过期时间
                signingCredentials: cred
                );

            var handler = new JwtSecurityTokenHandler();

            //生成令牌
            string jwt = handler.WriteToken(token);

            return new TokenDto { Code = 0, Msg = "登录成功", Token = jwt };
        }

        public Tuple<List<AdminListDto>, int> Page(int PageIndex = 1, int PageSize = 10)
        {
            var list = mapper.Map<List<AdminListDto>>(AdminRepository.GetQuery().OrderBy(m => m.AdminId).Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList());
            //Foreach
            /*list.ForEach(m =>
            {
                m.CreateTime = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(m.CreateTime));
            });*/

            var toalCount = AdminRepository.GetQuery().Count();
            return new Tuple<List<AdminListDto>, int>(list, toalCount);
        }

        public ResultDto Register(AdminDto dto)
        {
            if (AdminRepository.GetEntity(m => m.UserName == dto.UserName.Trim().ToUpper()) != null)
            {
                return new ResultDto { Code = 1, Msg = "已存在此用户" };
            }

            //密码、注册时间、末次登录时间
            dto.UserName = dto.UserName.Trim().ToUpper();
            dto.Password = Md5(dto.Password.Trim());
            dto.CreateTime = DateTime.Now;
            dto.LastLoginTime = null;

            var Entity = mapper.Map<Admin>(dto);

            AdminRepository.Create(Entity);

            //批量管理员、角色的中间表
            /*var list = dto.RoleId.Select(m => new AdminRole { RoleId = m, AdminId = Entity.AdminId }).ToList();

            adminRoleRepository.BulkCreate(list);*/

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
