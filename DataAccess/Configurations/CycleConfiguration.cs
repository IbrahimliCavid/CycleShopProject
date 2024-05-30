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
    public class CycleConfiguration : IEntityTypeConfiguration<Cycle>
    {
      
        public void Configure(EntityTypeBuilder<Cycle> builder)
        {
            builder.ToTable("Cycles");
            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRAYMARY_KEY_SEED_VALUE, increment: 1);
            builder.Property(x => x.Model)
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
            builder.Property(x => x.IsTrend)
                .HasDefaultValue(false);
            builder.HasIndex(x => new { x.Model, x.CategoryId, x.Deleted })
                .IsUnique();
         

            // No configuration needed here
            // as it's a mirrored relationship of CategoryConfiguration and CartConfiguration
        }
    }
}
