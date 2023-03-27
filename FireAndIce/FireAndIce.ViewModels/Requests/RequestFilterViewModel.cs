namespace FireAndIce.ViewModels.Requests
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Linq;

    public class RequestFiltersViewModel
    {
        public string ClientId { get; set; }
        public string TechId { get; set; }
        [Display(Name = "Enter name")]

        public string CustomerName { get; set; }

        public string Status { get; set; }
    }
}
