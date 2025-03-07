﻿
using DemoProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Database
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();
            builder.Entity<Person>().Property(p => p.Name).HasMaxLength(450);
            builder.Entity<Person>().Property(p => p.Email).HasMaxLength(100);
            builder.Entity<Person>().Property(p => p.PhoneNumber).HasMaxLength(10);
            Seeder.RoleSeeder(builder);
            Seeder.FirstUserSeeder(builder);
        }
        public virtual DbSet<Person> Persons { get; set; }
    }
}
