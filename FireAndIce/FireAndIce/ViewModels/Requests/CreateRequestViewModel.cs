using System.ComponentModel.DataAnnotations;

namespace FireAndIce.ViewModels.Requests
{
    public class CreateRequestViewModel
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        public string Url { get; set; }

        public string UserId { get; set; }
    }
}
