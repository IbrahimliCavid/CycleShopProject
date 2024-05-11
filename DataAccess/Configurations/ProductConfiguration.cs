using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        //    [NotMapped]
        //    private double _price = 0;
        //    public Product()
        //    {
        //        Carts = new HashSet<Cart>();
        //    }
        //    public string Name { get; set; }
        //    public int CategoryId { get; set; }
        //    public string ImgUrl { get; set; }
        //    public double Price
        //    {

        //        get
        //        {
        //            var newPrice = _price * (100 - PrecentOfDiscount) / 100;
        //            return newPrice;
        //        }
        //        set
        //        {
        //            _price = value;
        //        }
        //    }
        //    public byte PrecentOfDiscount { get; set; } = 0;
        //    [NotMapped]
        //    public byte StarRating { get; set; }
        //    public int ShopId { get; set; }
        //    public virtual ICollection<Cart> Carts { get; set; }
        //    public virtual Category Category { get; set; }
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRAYMARY_KEY_SEED_VALUE, increment: 1);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(x => x.CategoryId)
                .IsRequired();
            builder.Property(x => x.ImgUrl)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(x => x.Price)
                .IsRequired();
            builder.Property(x => x.PrecentOfDiscount)
            .HasDefaultValue(0);
            builder.Property(x => x.IsHomePage)
                .HasDefaultValue(false);
            builder.HasIndex(x => new { x.Name, x.ImgUrl, x.Deleted });

            // No configuration needed here
            // as it's a mirrored relationship of CategoryConfiguration and CartConfiguration




        }
    }
}
