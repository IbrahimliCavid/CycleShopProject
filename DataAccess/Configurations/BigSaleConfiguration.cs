﻿using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class BigSaleConfiguration : IEntityTypeConfiguration<BigSale>
    {
        public void Configure(EntityTypeBuilder<BigSale> builder)
        {
            builder.ToTable("BigSales");
            builder.Property(x => x.Id)
                 .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRAYMARY_KEY_SEED_VALUE,increment:1);
            builder.Property(x => x.ImgUrl)
                .IsRequired()
                .HasMaxLength(200);
         

            //Has Not Relationship
        }
    }
}
