﻿using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRAYMARY_KEY_SEED_VALUE, increment: 1);
            builder.Property(x => x.SubTotal)
                 .HasPrecision(7, 2)
                .IsRequired();
            builder.Property(x => x.Delivery)
                .IsRequired();
            builder.Property(x => x.Commision)
                .HasDefaultValue(1);
            builder.Property(x => x.IsDelivery)
                .HasDefaultValue(false);
            builder.Property(x => x.CartId)
                .IsRequired();
            builder.Property(x => x.ShippingAdressId)
                .IsRequired();

            //Relationship between Order and Cart
            builder.HasOne(x => x.Cart)
               .WithOne()
               .HasForeignKey<Order>(x => x.CartId);

            //Relationship between Order and ShippingAdress
            builder.HasOne(x => x.ShippingAdress)
           .WithMany()
           .HasForeignKey(x => x.ShippingAdressId)
           .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
