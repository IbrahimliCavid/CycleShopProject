using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class About : BaseEntity
    {
        public About()
        {
            Activities = new HashSet<Activity>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Activity> Activities { get; set; }

    }

    public class Activity : BaseEntity
    {
        public int AboutId { get; set; }
        public string ActivityInfo { get; set; }
        public virtual About About { get; set; }
    }
    public class Service : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsHomePage { get; set; }
        public string ImgUrl { get; set; }
    }
    public class Product : BaseEntity
    {

        public Product()
        {
            Carts = new HashSet<Cart>();
        }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string ImgUrl { get; set; }
        public short Price { get; set; }
        public byte PrecentOfDiscount { get; set; }
        public short NewPrice { get; set; }
        public byte StarRating { get; set; }
        public int ShopId { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual Category Category { get; set; }
    }
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
    public class Testimonial : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
    }
    public class BestRacer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Info { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink {  get; set; }
        public string TwitterLink {  get; set; }
        public string EmailLink {  get; set; }

    }

    public class BigSale : BaseEntity
    {
        public string ImgUrl { get; set; }
    }
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Message { get; set; }
    }
    public class Cart : BaseEntity
    {
        public Cart()
        {
            Products = new HashSet<Product>();
        }
        public short Count { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
    public class Order : BaseEntity
    {
        public int CartId { get; set; }
        public int ShippingAdressId { get; set; }
        public int SubTotal { get; set; }
        public short Delivery { get; set; }
        public short Commision { get; set; }
        public int GrandTotal { get; set; }
        public bool IsDelivery { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ShippingAdress ShippingAdress { get; set; }
    }
    public class ShippingAdress : BaseEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostalCode { get; set; }
        public string Adress { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public User User { get; set; }
    }
    public class User : BaseEntity
    {
        public User()
        {
            ShippingAdresses = new HashSet<ShippingAdress>();
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<ShippingAdress> ShippingAdresses { get; set; }
    }
    public class Subcribe : BaseEntity
    {
        public string Email { get; set; }
    }
}
