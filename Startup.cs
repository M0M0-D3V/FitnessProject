using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FitnessProject
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddDbContext<MyContext>(options => options.UseMySql(Configuration["DBInfo:ConnectionString"]));
            
            services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<MyContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
                {
                    options.LoginPath = new PathString("/signin");
                    options.AccessDeniedPath = new PathString("/signin");
                });

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddAuthentication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseSession();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
