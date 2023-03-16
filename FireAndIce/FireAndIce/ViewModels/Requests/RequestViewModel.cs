﻿using FireAndIce.Data.Models.Enums;
using System;

namespace FireAndIce.ViewModels.Requests
{
    public class RequestViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; }

        public string VisitDate { get; set; }

        public string TechFullName { get; set; }

        public string CustomerFullName { get; set; }

    }
}
