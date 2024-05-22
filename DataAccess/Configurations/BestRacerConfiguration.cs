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
    public class BestRacerConfiguration : IEntityTypeConfiguration<BestRacer>
    {
        public void Configure(EntityTypeBuilder<BestRacer> builder)
        {

            builder.ToTable("BestRacers");
            builder.Property(x => x.Id)
                    .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRAYMARY_KEY_SEED_VALUE, increment: 1);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Info)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(x => x.FacebookLink)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(x => x.InstagramLink)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(x => x.TwitterLink)
                .IsRequired()
                .HasMaxLength(150); 
            builder.Property(x => x.EmailLink)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(x => x.ImgUrl)
                .IsRequired()
                .HasMaxLength(200);
            builder.HasIndex(x => new { x.InstagramLink,x.Deleted })
                .IsUnique();  
            builder.HasIndex(x => new { x.EmailLink, x.Deleted })
                .IsUnique();  
            builder.HasIndex(x => new { x.FacebookLink, x.Deleted })
                .IsUnique();  
            builder.HasIndex(x => new { x.TwitterLink, x.Deleted })
                .IsUnique();
            //Has Not Relationship
        }
    }
}
