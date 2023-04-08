using Cars.ViewModels.Shared;
using System.Collections;
using System.Collections.Generic;

namespace Cars.ViewModels.Cars
{
    public class IndexCarsViewModel : PagingViewModel
    {
        public ICollection<IndexCarViewModel> Cars { get; set; } = new List<IndexCarViewModel>();
    }
}
