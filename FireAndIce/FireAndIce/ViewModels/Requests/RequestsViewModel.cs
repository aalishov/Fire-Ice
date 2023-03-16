using FireAndIce.ViewModels.Shared;
using System.Collections.Generic;

namespace FireAndIce.ViewModels.Requests
{
    public class RequestsViewModel : PagingViewModel
    {
        public ICollection<RequestViewModel> Requests { get; set; }

        public RequestFiltersViewModel Filter { get; set; } = new RequestFiltersViewModel();

    }
}
