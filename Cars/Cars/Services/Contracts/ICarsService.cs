using Cars.ViewModels.Cars;
using System.Threading.Tasks;

namespace Cars.Services.Contracts
{
    public interface ICarsService
    {
        Task<IndexCarsViewModel> GetCarsAsync(IndexCarsViewModel model);

        Task<IndexCarViewModel> GetCarDetailsAsync(string id);

        Task CreateCarAsync(CreateCarViewModel model);
    }
}
