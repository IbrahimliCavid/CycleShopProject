using Entities.Concrete.MemberShip;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlServerDbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = Localhost; Initial Catalog = MyCycleDb; Integrated Security = true; Encrypt = false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

 

        public DbSet<About> Abouts { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<BestRacer> BestRacers { get; set; }
        public DbSet<BigSale> BigSales { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories {  get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cycle> Cycles {  get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ShippingAdress> ShippingAdresses { get; set; }
        public DbSet<Subscribe> Subcribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
