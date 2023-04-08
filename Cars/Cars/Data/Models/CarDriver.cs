namespace Cars.Data.Models
{
    public class CarDriver
    {
        public string CarId { get; set; }

        public virtual Car Car { get; set; }

        public string DriverId { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
