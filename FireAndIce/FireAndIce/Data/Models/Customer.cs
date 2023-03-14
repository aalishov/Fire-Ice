namespace FireAndIce.Data.Models
{
    public class Customer
    {
        public string Id { get; set; }

        public string Address { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
