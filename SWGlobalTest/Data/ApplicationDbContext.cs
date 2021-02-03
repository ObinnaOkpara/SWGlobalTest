using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SWGlobalTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWGlobalTest.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Complaint> Complaints { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            #region Seed Data
            var role = new IdentityRole { Name = Constants.AdminRole, NormalizedName = Constants.AdminRole.ToUpper(), Id = "02174cf0-9412-4cfe-afbf-59f706d72c8e", ConcurrencyStamp = "46b5ea46-80ab-4fba-8507-4908ac269d00" };
            builder.Entity<IdentityRole>().HasData(role);

            var email = "admin@gmail.com";
            var appUser = new AppUser { Id = "02174cf0-9412-4cfe-afbf-59f706d72cff", Email = email,
                EmailConfirmed = true, FirstName = "Admin", LastName = "SWGlobal", UserName = email,
                NormalizedEmail = email.ToUpper(), NormalizedUserName = email.ToUpper(),
            };

            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "administrator");

            builder.Entity<AppUser>().HasData(appUser);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { RoleId = role.Id, UserId = appUser.Id });

            #endregion
        }
    }
}
