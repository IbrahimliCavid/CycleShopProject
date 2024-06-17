using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItems");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed:DefaultConstantValue.DEFAULT_PRAYMARY_KEY_SEED_VALUE, increment:1);

            builder.Property(x => x.Quantity)
                .HasDefaultValue(1);

            //builder.HasIndex(x => new { x.CycleId, x.CartId})
            //    .IsUnique();

            //Relotionship between CartItem and Cart
            builder.HasOne(x => x.Cart)
                .WithMany(x=>x.CartItems)
                .HasForeignKey(x => x.CartId);

            //Relotionship between CartItem and Cycle
            builder.HasOne(x=>x.Cycle)
                .WithOne()
                .HasForeignKey<CartItem>(x => x.CycleId);
        }
    }
}
