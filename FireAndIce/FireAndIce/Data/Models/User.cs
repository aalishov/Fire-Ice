﻿namespace FireAndIce.Data.Models
{
    using System;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Tech Tech { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
