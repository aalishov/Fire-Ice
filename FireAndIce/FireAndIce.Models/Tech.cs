namespace FireAndIce.Models
{
    using System;
    using System.Collections.Generic;

    public class Tech
    {
        public Tech()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public decimal Salary { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
    }
}
