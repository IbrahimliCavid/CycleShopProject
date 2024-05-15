using Core.DefaultValues;
using DataAccess.SqlServerDbContext;
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
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.ToTable("Abouts");
            builder.Property(x => x.Id)
                 .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRAYMARY_KEY_SEED_VALUE, increment:1);
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(300);
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(2000);
            //Has not Relationship
        }
    }
}
