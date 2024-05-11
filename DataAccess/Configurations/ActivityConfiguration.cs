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
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable("Activities");
            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRAYMARY_KEY_SEED_VALUE, increment: 1);
            builder.Property(x => x.ActivityInfo)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(x => x.AboutId)
                .IsRequired();
            builder.HasIndex(x => new {x.ActivityInfo, x.Deleted})
                .IsUnique();

            //Relationship between About and Activity
            builder.HasOne(x => x.About)
                .WithMany(x => x.Activities)
                .HasForeignKey(x => x.AboutId);

                
        }
    }
}
