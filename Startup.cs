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
                    options.LoginPath = new PathString("/Signin");
                    options.AccessDeniedPath = new PathString("/Signin");
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

            InitializeRoles(app.ApplicationServices).Wait();

            app.UseMvc();
        }

        private async Task InitializeRoles(IServiceProvider serviceProvider)
        {
            // Array of Roles to create
            // RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            
            string[] RolesToCreate = new string[] { "Student", "Instructor", "Admin" };
            
            IdentityResult roleResult;

            foreach (string role in RolesToCreate)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                // If a Role doesn't already exist, create it
                if(!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
