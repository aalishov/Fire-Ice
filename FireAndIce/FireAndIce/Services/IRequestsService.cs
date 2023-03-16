using FireAndIce.ViewModels.Requests;
using System.Threading.Tasks;

namespace FireAndIce.Services
{
    public interface IRequestsService
    {
        Task<RequestsViewModel> GetRequestsAsync(RequestsViewModel model);

        Task CreateRequestAsync(CreateRequestViewModel model);
    }
}