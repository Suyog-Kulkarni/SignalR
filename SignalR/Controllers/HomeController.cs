using Microsoft.AspNetCore.Mvc;
using SignalR.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.SignalR;
using SignalR.Hubs;

namespace SignalR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<UserHub> _hubContext;

        private readonly Messages messages = new();

        public HomeController(ILogger<HomeController> logger, IHubContext<UserHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task Task()
        {
          
            await _hubContext.Clients.All.SendAsync("updateTotalViews", UserHub.TotalViews);
            await _hubContext.Clients.All.SendAsync("updateMessage", messages.Message);
        }
    }
}
