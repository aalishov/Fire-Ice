using System;
using System.Collections.Generic;

namespace Cars.Data.Models
{
    public class Driver
    {
        public Driver()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<CarDriver> Cars { get; set; } = new List<CarDriver>();

    }
}
