using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            services.AddDbContext<ProjectDbContext>(options =>options.UseSqlServer("server= (localdb)\\mssqllocaldb; database = StockDb"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestStock.API", Version = "v1" });
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IOrderRepository, OrderRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IRoleRepository, RoleRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            //services.AddScoped<IAuthService, AuthManager>();
            //services.AddScoped<IOrderService,OrderManager>();
            //services.AddScoped<IProductService,ProductManager>();
            //services.AddScoped<IUserService,UserManager>();

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
