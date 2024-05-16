﻿using Core.DefaultValues;
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
    public class CycleConfiguration : IEntityTypeConfiguration<Product>
    {
      
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
            builder.Property(x => x.Count)
                .HasDefaultValue(0);
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