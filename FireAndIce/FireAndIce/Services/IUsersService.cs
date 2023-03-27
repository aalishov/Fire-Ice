namespace FireAndIce.Services
{
    using System.Threading.Tasks;
    using FireAndIce.ViewModels.Users;

    public interface IUsersService
    {
        Task CreateTechAsync(CreateTechViewModel model);

        Task<UserViewModel> GetUserByIdAsync(string id);

        Task<UsersViewModel> GetUsersAsync(int page = 1, int count = 10);

        Task DeleteUserByIdAsync(string id);

        Task<EditUserViewModel> GetUserToEditByIdAsync(string id);

        Task UpdateUserAsync(EditUserViewModel model);
    }
}