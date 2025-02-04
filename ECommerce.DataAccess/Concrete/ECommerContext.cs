﻿using ECommerce.Core.Entities.Concrete;
using ECommerce.DataAccess.Mappings.CategoryMapping;
using ECommerce.DataAccess.Mappings.OperationClaimMapping;
using ECommerce.DataAccess.Mappings.ProductMapping;
using ECommerce.DataAccess.Mappings.UserMapping;
using ECommerce.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete
{
    public class ECommerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ECommerceDb;Trusted_Connection=true;");
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-1D5ONEF\SQLEXPRESS03;Database=ECommerceDb;Trusted_Connection=true;TrustServerCertificate=True");
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new OperationClaimMap());


        }
    }
}
