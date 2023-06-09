﻿namespace FireAndIce.ViewModels.Requests
{
    using FireAndIce.Models.Enums;
    using Microsoft.AspNetCore.Http;

    public class RequestViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; }

        public string VisitDate { get; set; }

        public string TechFullName { get; set; }

        public string CustomerFullName { get; set; }

        public string Url { get; set; }

        public IFormFile Picture { get; set; }
    }
}
