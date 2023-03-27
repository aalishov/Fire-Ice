namespace FireAndIce.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using FireAndIce.Data.Models;
    using FireAndIce.Services;
    using FireAndIce.ViewModels.Requests;
    using FireAndIce.ViewModels.Tech;
    using FireAndIce.ViewModels.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    [Authorize]
    public class RequestsController : Controller
    {
        private readonly IRequestsService requestsService;
        private readonly UserManager<User> userManager;

        public RequestsController(IRequestsService requestsService, UserManager<User> userManager)
        {
            this.requestsService = requestsService;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index(RequestsViewModel model)
        {
            if (this.User != null && this.User.IsInRole("Customer"))
            {
                model.Filter.ClientId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            if (this.User != null && this.User.IsInRole("Tech"))
            {
                model.Filter.TechId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            model = await requestsService.GetRequestsAsync(model);

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRequestViewModel model)
        {
            model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            if (ModelState.IsValid)
            {
                await requestsService.CreateRequestAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditByCustomer(string id)
        {
            EditCustomerRequestViewModel model = await requestsService.GetRequestToEditByCustomerAsync(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditByCustomer(EditCustomerRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                await requestsService.EditRequestByCustomerAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditByAdmin(string id)
        {

            EditAdminRequestViewModel model =await requestsService.GetRequestToEditByAdminAsync(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditByAdmin(EditAdminRequestViewModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await requestsService.EditRequestByAdminAsync(model);
                }
                catch (Exception) 
                {
                    model.Techs = new SelectList(await requestsService.GetTechesAsync(),"Id","FullName");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [Authorize(Roles = "Admin,Customer")]
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await requestsService.DeleteRequest(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
