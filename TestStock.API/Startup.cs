using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Abstract;
using TestStock.BLL.Concrete;
using TestStock.BLL.Repositories;
using TestStock.BLL.Repositories.Abstract;
using TestStock.BLL.Repositories.Concrete;
using TestStock.DAL.Context;

namespace TestStock.API
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
            services.AddDbContext<ProjectDbContext>(options =>options.UseSqlServer("Server=coinodb-dev.cjq6i1xxy6zz.eu-central-1.rds.amazonaws.com;Database=ElenStockProject;Uid=sa;Password=DtzsCI3HF9n4WIX7O3dj6SSdC43PdpwpMtcaXtDlj8TJy3KDSJ"));


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>{
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters=new TokenValidationParameters
                {
                    ValidIssuer="http://localhost",
                    ValidAudience= "http://localhost",
                    IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes("EzgiElenEzgiElen")),
                    ValidateIssuerSigningKey=true,
                    ValidateLifetime = true,     
                    ClockSkew=TimeSpan.Zero, //SUNCUCCU VE CL�ENT ARASINDA OLU�AB�LCEK ZAMAN FARKLILIKLARININ �N�NE GE�MEK ���N GEC�KME S�RES�  DEFAULT OLRK ATANIYOR BUNUN �N�NE GE�T�M

                };
               
            });
           

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestStock.API", Version = "v1" });
                c.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"

                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    new List<string>()
                }
            });
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerRoleRepository, CustomerRoleRepository>();
            //services.AddScoped<IUserRoleRepository, CustomerRoleRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IAuthService, NewAuthManager>();
            services.AddScoped<IOrderService,OrderManager>();
            services.AddScoped<IProductService,ProductManager>();
            services.AddScoped<ICustomerService,CustomerManager>();
            services.AddScoped<IRolesService, RolesManager>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestStock.API v1"));
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
