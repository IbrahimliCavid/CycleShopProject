using Buisness.Abstract;
using Buisness.Concrete;
using Buisness.Validations;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.SqlServerDbContext;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace CycleStore.Web.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //builder.Services.AddScoped();
            //builder.Services.AddTransient()
            //builder.Services.AddSingleton()
            builder.Services.AddDbContext<ApplicationDbContext>();

            builder.Services.AddScoped<IAboutService, AboutManager>();
            builder.Services.AddScoped<IAboutDal, AboutDal>();
            builder.Services.AddScoped<IValidator<About>, AboutValidation>();

            builder.Services.AddScoped<IActivityService, ActivityManager>();
            builder.Services.AddScoped<IActivityDal, ActivityDal>();

            builder.Services.AddScoped<IBestRacerService, BestRacerManager>();
            builder.Services.AddScoped<IBestRacerDal, BestRacerDal>();

            builder.Services.AddScoped<IBigSaleService, BigSaleManager>();
            builder.Services.AddScoped<IBigSaleDal, BigSaleDal>();

            builder.Services.AddScoped<ICategoryService, CategoryManager>();
            builder.Services.AddScoped<ICategoryDal, CategoryDal>();

            builder.Services.AddScoped<IContactService, ContactManager>();
            builder.Services.AddScoped<IContactDal, ContactDal>();

            builder.Services.AddScoped<ICycleService, CycleManager>();
            builder.Services.AddScoped<ICycleDal, CycleDal>();

            builder.Services.AddScoped<IServiceService, ServiceManager>();
            builder.Services.AddScoped<IServiceDal, ServiceDal>();

            builder.Services.AddScoped<ISubscribeService, SubscribeManager>();
            builder.Services.AddScoped<ISubscribeDal, SubscribeDal>();

            builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
            builder.Services.AddScoped<ITestimonialDal, TestimonialDal>();

            builder.Services.AddScoped<IUserService, UserManager>();
            builder.Services.AddScoped<IUserDal, UserDal>();






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

            app.UseAuthorization();

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
