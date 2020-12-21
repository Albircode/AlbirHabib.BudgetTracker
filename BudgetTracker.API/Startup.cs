using BudgetTracker.Core.RepositoryInterfaces;
using BudgetTracker.Core.ServiceInterfaces;
using BudgetTracker.Infrastracture.Data;
using BudgetTracker.Infrastracture.Repositories;
using BudgetTracker.Infrastracture.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTracker.API
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
            services.AddControllers();
            services.AddDbContext<UserDbcontext>(options =>

                options.UseSqlServer(Configuration.GetConnectionString(("UsersDbConnection"))));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IIncomeService, IncomeService>();
            services.AddScoped<IIncomeRepository, IncomeRepository>();

            services.AddScoped<IExpenditureService, ExpenditurService>();
            services.AddScoped<IExpenditureRepository, ExpenditureRepository>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder =>

            {

                builder.WithOrigins(Configuration.GetValue<string>("clientSPAUrl")).AllowAnyHeader()

                    .AllowAnyMethod()

                    .AllowCredentials();

            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
