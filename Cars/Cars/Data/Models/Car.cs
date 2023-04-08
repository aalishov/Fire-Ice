using Cars.Data.Models.Enums;
using System;
using System.Collections.Generic;

namespace Cars.Data.Models
{
    public class Car
    {
        public Car()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public Color Color { get; set; }

        public virtual ICollection<CarDriver> Drivers { get; set; } = new List<CarDriver>();
    }
}
