using Cars.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<Driver> Drivers { get; set; }

        public virtual DbSet<CarDriver> CarsDrivers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CarDriver>()
                .HasKey(x => new {x.CarId,x.DriverId});
        }
    }
}
