using Cars.Data.Models.Enums;

namespace Cars.ViewModels.Cars
{
    public class CreateCarViewModel
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public Color Color { get; set; }
    }
}
