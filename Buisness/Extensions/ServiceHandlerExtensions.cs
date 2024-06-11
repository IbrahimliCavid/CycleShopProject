using Buisness.Abstract;
using Buisness.Concrete;
using Buisness.Validations;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Buisness.Extensions
{
    public static class ServiceHandlerExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            //About Services
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, AboutDal>();
            services.AddScoped<IValidator<About>, AboutValidation>();

            //Activity Services
            services.AddScoped<IActivityService, ActivityManager>();
            services.AddScoped<IActivityDal, ActivityDal>();
            services.AddScoped<IValidator<Activity>, ActivityValidation>();

            //BestRacer Services
            services.AddScoped<IBestRacerService, BestRacerManager>();
            services.AddScoped<IBestRacerDal, BestRacerDal>();
            services.AddScoped<IValidator<BestRacer>, BestRacerValidation>();

            //BigSale Services
            services.AddScoped<IBigSaleService, BigSaleManager>();
            services.AddScoped<IBigSaleDal, BigSaleDal>();
            services.AddScoped<IValidator<BigSale>, BigSaleValidation>();

            //Category Services
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<IValidator<Category>, CategoryValidation>();

            //Contact Services
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, ContactDal>();
            services.AddScoped<IValidator<Contact>, ContactValidation>();

            //Cycle Services
            services.AddScoped<ICycleService, CycleManager>();
            services.AddScoped<ICycleDal, CycleDal>();
            services.AddScoped<IValidator<Cycle>, CycleValidation>();

            //Service Services
            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<IServiceDal, ServiceDal>();
            services.AddScoped<IValidator<Service>, ServiceValidation>();

            //Subscribe Services
            services.AddScoped<ISubscribeService, SubscribeManager>();
            services.AddScoped<ISubscribeDal, SubscribeDal>();
            services.AddScoped<IValidator<Subscribe>, SubscribeValidation>();

            //Testimonial Services
            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<ITestimonialDal, TestimonialDal>();
            services.AddScoped<IValidator<Testimonial>, TestimonialValidation>();

            //ShippingAdress Services
            services.AddScoped<IShippingAdressService, ShippingAdressManager>();
            services.AddScoped<IShippingAdressDal, ShippingAdressDal>();
            services.AddScoped<IValidator<ShippingAdress>, ShippingAdressValidation>();
            
            //ShippingAdress Services
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<ICartDal, CartDal>();
            services.AddScoped<IValidator<Cart>, CartValidation>();


        }
    }
}
