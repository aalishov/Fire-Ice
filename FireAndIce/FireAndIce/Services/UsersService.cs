using FireAndIce.Data;
using FireAndIce.Data.Models;
using Microsoft.AspNetCore.Identity;
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

        public async Task CreateTech(string email, string password, string firstName, string lastName, decimal salary)
        {
            User user = new User()
            {
                Email = email,
                UserName= email,
                FirstName = firstName,
                LastName = lastName,
                EmailConfirmed = true,
            };
            await userManager.CreateAsync(user, password);

            Tech tech = new Tech()
            {
                User = user,
                Salary = salary
            };

            await context.Teches.AddAsync(tech);
            await context.SaveChangesAsync();
        }
    }
}
