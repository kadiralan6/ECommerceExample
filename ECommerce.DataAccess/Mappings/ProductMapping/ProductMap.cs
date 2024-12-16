using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECommerce.Entities.Concrete;

namespace ECommerce.DataAccess.Mappings.ProductMapping
{

    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Code).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(p => p.CreateDate).IsRequired();
            builder.Property(p => p.EditDate).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.Deleted).IsRequired();
            builder.Property(p => p.Price).IsRequired();

            builder.HasOne<Category>(a => a.Category).WithMany(a => a.Products).HasForeignKey(a => a.CategoryId);
           
        }

     
    }

}
