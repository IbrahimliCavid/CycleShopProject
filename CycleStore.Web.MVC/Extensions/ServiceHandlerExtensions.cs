using Buisness.Abstract;
using Buisness.Concrete;
using Buisness.Validations;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace CycleStore.Web.MVC.Extensions
{
    public static class ServiceHandlerExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            //About
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, AboutDal>();
            services.AddScoped<IValidator<About>, AboutValidation>();

            services.AddScoped<IActivityService, ActivityManager>();
            services.AddScoped<IActivityDal, ActivityDal>();
            services.AddScoped<IValidator<Activity>, ActivityValidation>();

            services.AddScoped<IBestRacerService, BestRacerManager>();
            services.AddScoped<IBestRacerDal, BestRacerDal>();
            services.AddScoped<IValidator<BestRacer>, BestRacerValidation>();

            services.AddScoped<IBigSaleService, BigSaleManager>();
            services.AddScoped<IBigSaleDal, BigSaleDal>();
            services.AddScoped<IValidator<BigSale>, BigSaleValidation>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<IValidator<Category>, CategoryValidation>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, ContactDal>();
            services.AddScoped<IValidator<Contact>, ContactValidation>();

            services.AddScoped<ICycleService, CycleManager>();
            services.AddScoped<ICycleDal, CycleDal>();
            services.AddScoped<IValidator<Cycle>, CycleValidation>();

            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<IServiceDal, ServiceDal>();
            services.AddScoped<IValidator<Service>, ServiceValidation>();

            services.AddScoped<ISubscribeService, SubscribeManager>();
            services.AddScoped<ISubscribeDal, SubscribeDal>();
            services.AddScoped<IValidator<Subscribe>, SubscribeValidation>();

            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<ITestimonialDal, TestimonialDal>();
            services.AddScoped<IValidator<Testimonial>, TestimonialValidation>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDal, UserDal>();
            services.AddScoped<IValidator<User>, UserValidation>();
        }
    }
}
