using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rbac.Entity;
using Rbac.Repository;
using Rbac.Application;
using System.Reflection;
using Rbac.Application.Roles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Rbac.Application.Admins;
using Swashbuckle.AspNetCore.Filters;
using Rbac.Repository.MenuRoles;
using Rbac.Repository.AdminRoles;

namespace Rbac.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {

            });

            services.AddAutoMapper(Assembly.Load("Rbac.Application"));

            //ע??
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IMenuRoleRepository, MenuRoleRepository>();
            services.AddScoped<IAdminRoleRepository, AdminRoleRepository>();

            services.AddCors(option =>
            {
                option.AddDefaultPolicy(config =>
                {
                    config.WithOrigins("http://localhost:8080")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });

            services.AddDbContext<RbacDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
            });

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(
            option =>
            {
                //Token??֤????
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    //?Ƿ???֤??????
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["JwtConfig:Issuer"],//??????

                    //?Ƿ???֤??????
                    ValidateAudience = true,
                    ValidAudience = Configuration["JwtConfig:Audience"],//??????

                    //?Ƿ???֤??Կ
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtConfig:key"])),

                    ValidateLifetime = true, //??֤????????

                    RequireExpirationTime = true, //????ʱ??

                    ClockSkew = TimeSpan.Zero   //ƽ??????ƫ??ʱ??
                };
            }
);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Rbac.WebApi", Version = "v1" });

                //????Ȩ??С??
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                options.OperationFilter<SecurityRequirementsOperationFilter>();

                //??header??????token?????ݵ???̨
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT??Ȩ(???ݽ???????ͷ?н??д???)ֱ????????????????Bearer {token}(ע??????֮????һ???ո?) \"",
                    Name = "Authorization",//jwtĬ?ϵĲ???????
                    In = ParameterLocation.Header,//jwtĬ?ϴ???Authorization??Ϣ??λ??(????ͷ??)
                    Type = SecuritySchemeType.ApiKey
                });
            });
        }

        /// <summary>
        /// ?м???--HTTP?????ܵ?
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rbac.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            //??֤?м???
            app.UseAuthentication();

            //??Ȩ?м???
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
