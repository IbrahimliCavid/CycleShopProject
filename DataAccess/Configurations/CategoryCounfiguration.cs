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
    public class CategoryCounfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.Property(x=>x.Id)
                .UseIdentityColumn(seed:DefaultConstantValue.DEFAULT_PRAYMARY_KEY_SEED_VALUE, increment:1);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(x => new { x.Name, x.Deleted })
                .IsUnique();
           
            //Relationship between Category and Cycles
            builder.HasMany(x=>x.Cycles)
                .WithOne(x=>x.Category)
                .HasForeignKey(x=>x.CategoryId);
        }
    }
}
