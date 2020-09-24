using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Project.Blog.Business.Containers.MicrosoftIoC;
using Project.Blog.Business.StringInfos;
using Project.Blog.DataAccess.Concrete.EntityFrameworkCore.Context;
using Project.Blog.Entities.Concrete;
using Project.Blog.Web.CustomValidator;

namespace Project.Blog.Web
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

            //services.AddAutoMapper(typeof(Startup));
            services.AddDependencies();
            
            services.AddControllersWithViews();
            services.AddDbContext<BlogContext>();
            services.AddIdentity<User, Role>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                opt.Lockout.MaxFailedAccessAttempts = 3; // maximum number of failed attempts before the lockdown

            }).AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<BlogContext>();
            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Home/Login");
                opt.Cookie.HttpOnly = true;
                opt.Cookie.Name = "BlogCookie";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
            });
            //services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BlogContext>();
            

        }

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

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
