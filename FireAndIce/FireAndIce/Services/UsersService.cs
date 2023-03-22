using FireAndIce.Data;
using FireAndIce.Data.Models;
using FireAndIce.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FireAndIce.Services
{
    public class UsersService : IUsersService
    {
        private ApplicationDbContext context;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;

        public UsersService(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task DeleteUserByIdAsync(string id)
        {
            User user = await userManager.FindByIdAsync(id);

            await userManager.DeleteAsync(user);
        }

        public async Task CreateTechAsync(CreateTechViewModel model)
        {
            Tech tech = new Tech()
            {
                Salary = model.Salary
            };
            User user = new User()
            {
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                NormalizedEmail = model.Email,
                UserName = model.Email,
                NormalizedUserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailConfirmed = true,
                SecurityStamp = string.Empty,
                Tech = tech
            };

            await userManager.CreateAsync(user, model.Password);
            await userManager.AddToRoleAsync(user, nameof(Tech));
        }

        public async Task UpdateUserAsync(EditUserViewModel model)
        {
            User user = await context.Users.FindAsync(model.Id);

            string role = userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            // Change role
            if (role != model.Role)
            {
                user.Tech = null;
                user.Customer = null;
                if (model.Role == "Tech")
                {
                    Tech tech = new Tech() { Salary = 1500 };
                    user.Tech = tech;
                    await userManager.RemoveFromRoleAsync(user, nameof(Customer));
                    await userManager.AddToRoleAsync(user, nameof(Tech));
                }
                else
                {
                    Customer customer = new Customer();
                    user.Customer = customer;
                    await userManager.RemoveFromRoleAsync(user, nameof(Tech));
                    await userManager.AddToRoleAsync(user, nameof(Customer));
                }
            }
            
            await context.SaveChangesAsync();
        }
        public async Task<EditUserViewModel> GetUserToEditByIdAsync(string id)
        {
            User user = await context.Users.FindAsync(id);
            EditUserViewModel model = null;
            if (user != null)
            {
                model = new EditUserViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault()
                };
            }
            return model;
        }

        public async Task<UserViewModel> GetUserByIdAsync(string id)
        {
            User user = await context.Users.FindAsync(id);

            UserViewModel model = null;

            if (user != null)
            {
                model = new UserViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Role = userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault()
                };
            }

            return model;
        }

        public async Task<UsersViewModel> GetUsersAsync(int page = 1, int count = 10)
        {
            UsersViewModel model = new UsersViewModel();

            model.ItemsPerPage = count;
            model.Page = page;
            model.ElementsCount = await this.context.Users.CountAsync();

            model.Users = await this.context.Users
                  .Skip((page - 1) * count)
                  .Take(count)
                  .Select(x => new UserViewModel()
                  {
                      Id = x.Id,
                      FirstName = x.FirstName,
                      LastName = x.LastName,
                      Email = x.Email,
                      Role = userManager.GetRolesAsync(x).GetAwaiter().GetResult().FirstOrDefault()
                  }
              ).ToListAsync();

            return model;
        }
    }
}
