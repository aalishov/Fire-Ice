namespace FireAndIce.ViewModels.Requests
{
    using System;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class EditAdminRequestViewModel : EditCustomerRequestViewModel
    {
        public DateTime VisitDate { get; set; }

        public string TechId { get; set; }

        public SelectList Techs { get; set; }
    }
}
