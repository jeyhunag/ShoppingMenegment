using System;
using System.Collections.Generic;
using ShoppingMenegment.Models.Entity.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ShoppingMenegment.Models.Entity;

namespace ShoppingMenegment.Models.Data
{
    public partial class ShoppingMenegmentContext : IdentityDbContext<AppUser, AppRole, int, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public ShoppingMenegmentContext()
        {
        }

        public ShoppingMenegmentContext(DbContextOptions<ShoppingMenegmentContext> options)
            : base(options)
        {
        }



        public virtual DbSet<Branch> Branches { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Orderitem> Orderitems { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;
        public virtual DbSet<Basket> Baskets { get; set; }

        #region Membership
        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<AppUserRole> UserRoles { get; set; }
        public DbSet<AppUserClaim> UserClaims { get; set; }
        public DbSet<AppRoleClaim> RoleClaims { get; set; }
        public DbSet<AppUserToken> UserTokes { get; set; }
        public DbSet<AppUserLogin> UserLogins { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Membership
            modelBuilder.Entity<AppUser>(e =>
            {
                e.ToTable("Users", "Membership");
            });

            modelBuilder.Entity<AppUserRole>(e =>
            {
                e.ToTable("UserRoles", "Membership");
            });

            modelBuilder.Entity<AppUserClaim>(e =>
            {
                e.ToTable("UserClaims", "Membership");

            });

            modelBuilder.Entity<AppRole>(e =>
            {
                e.ToTable("Roles", "Membership");
            });

            modelBuilder.Entity<AppRoleClaim>(e =>
            {
                e.ToTable("RoleClaims", "Membership");
            });

            modelBuilder.Entity<AppUserLogin>(e =>
            {
                e.ToTable("UserLogins", "Membership");
            });

            modelBuilder.Entity<AppUserToken>(e =>
            {
                e.ToTable("UserTokens", "Membership");
            });
            #endregion
        }
    }
}
