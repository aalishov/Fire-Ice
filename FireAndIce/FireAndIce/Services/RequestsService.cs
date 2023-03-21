﻿using Castle.Core.Resource;
using FireAndIce.Data;
using FireAndIce.Data.Models;
using FireAndIce.Data.Models.Enums;
using FireAndIce.ViewModels.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
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

            model.Url = await ImageToStringAsync(model.Picture);// to save the image as base64String 

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

        public async Task EditRequestByCustomerAsync(EditCustomerRequestViewModel model)
        {
            Request request = await context.Requests.FindAsync(model.Id);

            request.Name = model.Name;
            request.Address = model.Address;
            request.Description = model.Description;
            if (model.Picture != null)
            {
                request.Url = await ImageToStringAsync(model.Picture);
            }

            context.Requests.Update(request);
            await context.SaveChangesAsync();
        }
        public async Task DeleteRequest(string id)
        {
            Request request = await context.Requests.FindAsync(id);

            if (request != null && request.Status == Status.Pending)
            {
                context.Remove(request);
                await context.SaveChangesAsync();
            }
        }

        public async Task<EditCustomerRequestViewModel> GetRequestToEditByCustomerAsync(string customerId)
        {
            Request request = await context.Requests.FindAsync(customerId);
            if (request != null)
            {
                EditCustomerRequestViewModel model = new EditCustomerRequestViewModel()
                {
                    Id = request.Id,
                    Name = request.Name,
                    Address = request.Address,
                    Description = request.Description,
                    Url = request.Url
                };
                return model;
            }
            return null;
        }

        public async Task<RequestsViewModel> GetRequestsAsync(RequestsViewModel model)
        {
            model.Requests = await context.Requests
                .Where(x => model.Filter.ClientId != null ? x.Customer.UserId == model.Filter.ClientId : x.Id != null)
                .Where(x => model.Filter.TechId != null ? x.Tech.UserId == model.Filter.TechId : x.Id != null)
                .Where(x => model.Filter.CustomerName != null ? (x.Customer.User.FirstName.StartsWith(model.Filter.CustomerName) || x.Customer.User.LastName.StartsWith(model.Filter.CustomerName)) : x.Id != null)
              .Where(x => model.Filter.Status != null ? x.Status == Enum.Parse<Status>(model.Filter.Status) : x.Id != null)
                .Skip((model.PageNumber - 1) * model.ItemsPerPage)
                .Take(model.ItemsPerPage)
                .Select(x => new RequestViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Status = x.Status,
                    Url = x.Url,
                    TechFullName = x.Tech != null ? $"{x.Tech.User.FirstName} {x.Tech.User.LastName}" : "none",
                    CustomerFullName = x.Customer != null ? $"{x.Customer.User.FirstName} {x.Customer.User.LastName}" : "none",
                    VisitDate = x.VisitDate != null ? $"{((DateTime)x.VisitDate).ToString("dd-MM-yyyy HH:mm")}" : "none"
                })
                .ToListAsync();

            model.ElementsCount = model.Requests.Count();

            return model;
        }


        private async Task<string> ImageToStringAsync(IFormFile file)
        {
            List<string> imageExtensions = new List<string>() { ".JPG", ".BMP", ".PNG" };


            if (file != null) // check if the user uploded something
            {
                var extension = Path.GetExtension(file.FileName); //get file extension
                if (imageExtensions.Contains(extension.ToUpperInvariant()))
                {
                    using var dataStream = new MemoryStream();
                    await file.CopyToAsync(dataStream);
                    byte[] imageBytes = dataStream.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
            return null;
        }
    }
}
