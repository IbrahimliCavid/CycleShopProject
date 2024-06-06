using Buisness.Abstract;
using Buisness.Concrete;
using Buisness.Validations;
using Buisness.Extensions;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.SqlServerDbContext;
using Entities.Concrete.TableModels;
using FluentValidation;
using Entities.Concrete.MemberShip;
using System;
using Microsoft.AspNetCore.Identity;

namespace CycleStore.Web.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();

            builder.Services.AddDbContext<ApplicationDbContext>()
       .AddIdentity<ApplicationUser, ApplicationRole>()
           .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 8;

                options.User.RequireUniqueEmail = true;
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                //options.AccessDeniedPath = "Account/AccountDenied";
                options.ExpireTimeSpan = TimeSpan.FromHours(2);
            });

            //Add custom services

            builder.Services.AddCustomServices();

            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseStatusCodePagesWithReExecute("/NotFound/ErrorNotFound/{0}");

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
            });



            app.Run();
        }
    }
}
