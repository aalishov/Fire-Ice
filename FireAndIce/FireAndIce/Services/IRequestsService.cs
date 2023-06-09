﻿namespace FireAndIce.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels.Requests;
    using ViewModels.Tech;

    public interface IRequestsService
    {

        Task CreateRequestAsync(CreateRequestViewModel model);

        Task DeleteRequest(string id);

        Task EditRequestByAdminAsync(EditAdminRequestViewModel model);

        Task EditRequestByCustomerAsync(EditCustomerRequestViewModel model);

        Task<RequestsViewModel> GetRequestsAsync(RequestsViewModel model);

        Task<EditCustomerRequestViewModel> GetRequestToEditByCustomerAsync(string customerId);

        Task<EditAdminRequestViewModel> GetRequestToEditByAdminAsync(string requestId);

        Task<List<TechSelectListViewModel>> GetTechesAsync();

        Task<EditTechRequestViewModel> GetRequestToEditByTechAsync(string id);

        Task EditRequestByTechAsync(EditTechRequestViewModel model);
    }
}