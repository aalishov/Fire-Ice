using FireAndIce.Data.Models;
using FireAndIce.Services;
using FireAndIce.ViewModels.Requests;
using FireAndIce.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;

namespace FireAndIce.Controllers
{
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
    }
}
