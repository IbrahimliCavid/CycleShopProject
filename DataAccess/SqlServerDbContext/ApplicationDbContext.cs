using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlServerDbContext
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = Localhost; Initial Catalog = MyCycleDb; Integrated Security = true; Encrypt = false;");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<BestRacer> BestRacers { get; set; }
        public DbSet<BigSale> BigSales { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories {  get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products {  get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ShippingAdress> ShippingAdresses { get; set; }
        public DbSet<Subscribe> Subcribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
