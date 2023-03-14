using FireAndIce.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FireAndIce.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tech>(
                entity =>
            {
                entity.HasOne(x => x.User)
                  .WithOne(x => x.Tech)
                 .HasForeignKey<Tech>(x => x.UserId); ;
            });

            builder.Entity<Customer>(
             entity =>
             {
                 entity.HasOne(x => x.User)
                 .WithOne(x => x.Customer)
                 .HasForeignKey<Customer>(x => x.UserId);
             });

            base.OnModelCreating(builder);
        }
    }
}
