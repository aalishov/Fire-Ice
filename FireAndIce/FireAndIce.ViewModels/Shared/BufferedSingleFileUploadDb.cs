namespace FireAndIce.ViewModels.Shared
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Linq;
    using Microsoft.AspNetCore.Http;

    public class BufferedSingleFileUploadDb
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}
