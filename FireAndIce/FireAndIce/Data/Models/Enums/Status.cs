using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FireAndIce.Data.Models.Enums
{
    public enum Status
    {
        Pending = 0,
        [Display(Name = "Pending visit")]
        PendingVisit = 1,
        [Display(Name = "In progress")]
        InProgress = 2,
        Finished = 3
    }
}
