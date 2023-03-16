using FireAndIce.Data;
using FireAndIce.Data.Models;
using FireAndIce.ViewModels.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FireAndIce.Services
{
    public class RequestsService : IRequestsService
    {
        private readonly ApplicationDbContext context;

        public RequestsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task CreateRequestAsync(CreateRequestViewModel model)
        {
            Customer customer = await context.Customers.FirstOrDefaultAsync(x => x.UserId == model.UserId);

            Request request = new Request()
            {
                Name = model.Name,
                Address = model.Address,
                Url = model.Url,
                Description = model.Description,
                Customer = customer,
            };

            await context.Requests.AddAsync(request);
            await context.SaveChangesAsync();
        }

        public async Task<RequestsViewModel> GetRequestsAsync(RequestsViewModel model)
        {
            model.Requests = await context.Requests
                .Where(x => model.Filter.ClientId != null ? x.Customer.UserId == model.Filter.ClientId : x.Id != null)
                .Where(x => model.Filter.TechId != null ? x.Tech.UserId == model.Filter.TechId : x.Id != null)
                .Where(x => model.Filter.CustomerName != null ? (x.Customer.User.FirstName.StartsWith(model.Filter.CustomerName) || x.Customer.User.LastName.StartsWith(model.Filter.CustomerName)) : x.Id != null)
                .Skip((model.PageNumber - 1) * model.ItemsPerPage)
                .Take(model.ItemsPerPage)
                .Select(x => new RequestViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Status = x.Status,
                    TechFullName = x.Tech != null ? $"{x.Tech.User.FirstName} {x.Tech.User.LastName}" : "none",
                    CustomerFullName = x.Customer != null ? $"{x.Customer.User.FirstName} {x.Customer.User.LastName}" : "none",
                    VisitDate = x.VisitDate != null ? $"{((DateTime)x.VisitDate).ToString("dd-MM-yyyy HH:mm")}" : "none"
                })
                .ToListAsync();

            model.ElementsCount = model.Requests.Count();

            return model;
        }
    }
}
