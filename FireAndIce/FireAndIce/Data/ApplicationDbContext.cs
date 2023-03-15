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
        public virtual DbSet<Tech> Teches { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            // User-Tech One-To-One
            builder.Entity<Tech>(
                entity =>
            {
                entity.HasOne(x => x.User)
                  .WithOne(x => x.Tech)
                 .HasForeignKey<Tech>(x => x.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // User-Customer One-To-One
            builder.Entity<Customer>(
             entity =>
             {
                 entity.HasOne(x => x.User)
                 .WithOne(x => x.Customer)
                 .HasForeignKey<Customer>(x => x.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
             });

            // Create user - administrator
            User admin = CreateUser("admin@abv.bg");

            builder.Entity<User>().HasData(admin);

            // Create roles
            IdentityRole adminRole = CreateRole("Admin");
            IdentityRole techRole = CreateRole("Tech");
            IdentityRole customerRole = CreateRole("Customer");

            builder.Entity<IdentityRole>(
                option =>
                {
                    option.HasData(new IdentityRole[]
                    {
                        adminRole,
                        techRole,
                        customerRole
                    }
                    );
                });


            //Add user to role
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRole.Id,
                UserId = admin.Id
            });

            Random random = new Random();

            //Add customers
            for (int i = 0; i < 100; i++)
            {
                User user = CreateUser($"customer{i}@abv.bg");
                Customer customer = new Customer()
                {
                    UserId = user.Id,
                    Address = $"Street {random.Next(1, 450)}"
                };

                builder.Entity<User>().HasData(user);
                builder.Entity<Customer>().HasData(customer);

                builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
                {
                    RoleId = customerRole.Id,
                    UserId = user.Id
                });
            }

            //Add teches
            for (int i = 0; i < 50; i++)
            {
                User user = CreateUser($"tech{i}@abv.bg");
                Tech tech = new Tech()
                {
                    Salary = (decimal)(3000 * random.NextDouble()),
                    UserId = user.Id,
                };

                builder.Entity<User>().HasData(user);
                builder.Entity<Tech>().HasData(tech);

                builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
                {
                    RoleId = techRole.Id,
                    UserId = user.Id
                });
            }
        }

        private static IdentityRole CreateRole(string roleName)
        {
            return new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = roleName, NormalizedName = roleName };
        }

        private User CreateUser(string email, string password = "123456")
        {
            List<string> firstName = new List<string>() { "John", "Alex", "Jane", "Jack" };
            List<string> lastName = new List<string>() { "Johnson", "Alexandrov" };
            Random random = new Random();
            var hasher = new PasswordHasher<IdentityUser>();
            //Create user
            User user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = email,
                NormalizedUserName = email,
                Email = email,
                NormalizedEmail = email,
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, password),
                SecurityStamp = string.Empty,
                FirstName = firstName[random.Next(0, firstName.Count)],
                LastName = lastName[random.Next(0, lastName.Count)]
            };
            return user;
        }
    }
}
