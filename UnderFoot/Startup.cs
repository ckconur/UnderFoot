using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderFoot.CustomValidations;
using UnderFoot.DataAccess;

namespace UnderFoot
{
    public class Startup
    {
        public IConfiguration configuration { get; } 
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UnderFootDBContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:UnderFootConnString"]);
            });

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            })
                .AddPasswordValidator<CustomPasswordValidator>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddEntityFrameworkStores<UnderFootDBContext>();

            CookieBuilder cookieBuilder = new CookieBuilder()
            {
                Name = "UnderFoot",
                HttpOnly = false,
                SameSite = SameSiteMode.Lax, 
                SecurePolicy = CookieSecurePolicy.SameAsRequest, 
            };

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Home/Index");
                options.LogoutPath = new PathString("/Home/LogOut");
                options.Cookie = cookieBuilder;
                options.ExpireTimeSpan = TimeSpan.FromDays(60);
                options.SlidingExpiration = true; 
            });


            services.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
