
namespace FireAndIce.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FireAndIce.ViewModels.Requests;
    using FireAndIce.ViewModels.Tech;

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