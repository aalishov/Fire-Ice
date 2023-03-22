using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace FireAndIce.ViewModels.Requests
{
    public class EditAdminRequestViewModel: EditCustomerRequestViewModel
    {
        public DateTime VisitDate { get; set; }

        public string TechId { get; set; }
        public SelectList Techs { get; set; }
    }
}
