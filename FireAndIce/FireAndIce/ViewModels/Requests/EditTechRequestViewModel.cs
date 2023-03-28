using FireAndIce.Data.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FireAndIce.ViewModels.Requests
{
    public class EditTechRequestViewModel
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string VisitDate { get; set; }

        [Required]
        public string Address { get; set; }

        public string Url { get; set; }

        public Status Status { get; set; }
    }
}
