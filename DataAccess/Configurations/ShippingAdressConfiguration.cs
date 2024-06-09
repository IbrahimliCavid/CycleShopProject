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
    public class ShippingAdressConfiguration : IEntityTypeConfiguration<ShippingAdress>
    {
        public void Configure(EntityTypeBuilder<ShippingAdress> builder)
        {
        builder.ToTable("ShippingAdresses");
            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRAYMARY_KEY_SEED_VALUE, increment: 1);
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x=>x.LastName)
                .IsRequired()
                .HasMaxLength (100);
            builder.Property(x=>x.PostalCode)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(x => x.Country)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.State)
                .IsRequired()
                .HasMaxLength(100);
                builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Adress)
                .IsRequired()
                .HasMaxLength(400);
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(13);
            builder.Property(x => x.UserId)
                .IsRequired();
          

            // No configuration needed here
            // as it's a mirrored relationship of UserConfiguration and OrderConfiguration
            builder.HasOne(x => x.Order)
                .WithOne(x => x.ShippingAdress)
                .HasForeignKey<Order>(x => x.ShippingAdressId);
        }
    }
}
