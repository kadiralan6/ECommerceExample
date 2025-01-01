using ECommerce.Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Mappings.UserMapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(a => a.Id);
            builder.Property(c=>c.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(a => a.LastName).IsRequired().HasMaxLength(50); ;
            builder.Property(a => a.Email).IsRequired().HasMaxLength(50); ;
            builder.Property(a => a.Status).IsRequired();
            builder.Property(a => a.PasswordSalt).IsRequired();
            builder.Property(a => a.PasswordHash).IsRequired();
        }
    }
}
