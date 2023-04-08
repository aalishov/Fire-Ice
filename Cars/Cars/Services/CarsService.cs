using Cars.Data;
using Cars.Data.Models;
using Cars.Data.Models.Enums;
using Cars.Services.Contracts;
using Cars.ViewModels.Cars;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Services
{
    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext context;

        public CarsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task CreateCarAsync(CreateCarViewModel model)
        {
            context.Add(new Car() { Brand = model.Brand, Color = model.Color, Model = model.Model });
            await context.SaveChangesAsync();
        }

        public async Task<IndexCarViewModel> GetCarDetailsAsync(string id)
        {
            Car x = await this.context.Cars.FindAsync(id);

            if (x == null)
            {
                return null;
            }

            return new IndexCarViewModel() { Brand = x.Brand, Color = x.Color.ToString(), Id = x.Id, Model = x.Model };
        }

        public async Task<IndexCarsViewModel> GetCarsAsync(IndexCarsViewModel model)
        {
            var r = string.IsNullOrWhiteSpace(model.Filters.FirstOrDefault());
            model.Cars = await this.context.Cars
                .Where(x => string.IsNullOrWhiteSpace(model.Filters.FirstOrDefault()) ? x != null : x.Brand.Contains(model.Filters.FirstOrDefault()))
                .Where(x => string.IsNullOrWhiteSpace(model.Filters.Skip(1).FirstOrDefault()) ? x != null : x.Model.Contains(model.Filters.Skip(1).FirstOrDefault()))
                .Skip((model.Page - 1) * model.ItemsPerPage)
                .Take(model.ItemsPerPage)
                .Select(x => new IndexCarViewModel() { Brand = x.Brand, Color = x.Color.ToString(), Id = x.Id, Model = x.Model })
                .ToListAsync();

            model.ElementsCount = await this.context.Cars
                .Where(x => string.IsNullOrWhiteSpace(model.Filters.FirstOrDefault()) ? x != null : x.Brand.Contains(model.Filters.FirstOrDefault()))
                .Where(x => string.IsNullOrWhiteSpace(model.Filters.Skip(1).FirstOrDefault()) ? x != null : x.Model.Contains(model.Filters.Skip(1).FirstOrDefault()))
                .CountAsync();

            return model;
        }
    }
}
