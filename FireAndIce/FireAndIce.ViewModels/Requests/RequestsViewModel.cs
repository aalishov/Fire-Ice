namespace FireAndIce.ViewModels.Requests
{
    using System.Collections.Generic;
    using FireAndIce.ViewModels.Shared;

    public class RequestsViewModel : PagingViewModel
    {
        public ICollection<RequestViewModel> Requests { get; set; }

        public RequestFiltersViewModel Filter { get; set; } = new RequestFiltersViewModel();

    }
}
