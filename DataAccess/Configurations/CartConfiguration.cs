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
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");
            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRAYMARY_KEY_SEED_VALUE, increment: 1);



            //Relotionship between Cart and User
            builder.HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<Cart>(x => x.UserId);

            builder.HasOne(x => x.Cycle)
                 .WithOne()
                 .HasForeignKey<Cart>(x => x.CycleId);

            //The relationship between Cart and Order is defined in the OrderConfiguration class.
        }
    }
}
