namespace FireAndIce.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Enums;

    public class Request
    {
        public Request()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        public string Url { get; set; }

        public Status Status { get; set; } = Status.Pending;

        public DateTime? VisitDate { get; set; }

        [Required]
        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public string TechId { get; set; }

        [ForeignKey("TechId")]
        public virtual Tech Tech { get; set; }
    }
}
