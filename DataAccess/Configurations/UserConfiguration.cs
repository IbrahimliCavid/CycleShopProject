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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRAYMARY_KEY_SEED_VALUE, increment: 1);
            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(x => new { x.Email, x.Deleted })
                .IsUnique();
            builder.HasIndex(x => new { x.UserName, x.Deleted })
                .IsUnique();

            //Relationship between User and ShippingAdresses
            builder.HasMany(x => x.ShippingAdresses)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            //The relationship between User and Cart is defined in the CartConfiguration class.
        }
    }
}
