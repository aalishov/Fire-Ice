using FireAndIce.Data.Models;
using FireAndIce.ViewModels.Requests;
using FireAndIce.ViewModels.Tech;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FireAndIce.Services
{
    public interface IRequestsService
    {
        Task<RequestsViewModel> GetRequestsAsync(RequestsViewModel model);

        Task CreateRequestAsync(CreateRequestViewModel model);

        Task DeleteRequest(string id);

        Task<EditCustomerRequestViewModel> GetRequestToEditByCustomerAsync(string customerId);

        Task EditRequestByCustomerAsync(EditCustomerRequestViewModel model);

        Task<EditAdminRequestViewModel> GetRequestToEditByAdminAsync(string requestId);
        Task EditRequestByAdminAsync(EditAdminRequestViewModel model);

        Task<List<TechSelectListViewModel>> GetTechesAsync();
    }
}