namespace FireAndIce.ViewModels.Requests
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class EditCustomerRequestViewModel
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        public string Url { get; set; }

        [BindProperty]
        public IFormFile Picture { get; set; }
    }
}
