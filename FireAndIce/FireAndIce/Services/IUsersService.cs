using System.Threading.Tasks;

namespace FireAndIce.Services
{
    public interface IUsersService
    {
        Task CreateTech(string email, string password, string firstName, string lastName, decimal salary);
    }
}