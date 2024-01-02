using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.Hubs;
using SignalR.Models;

namespace SignalR.Controllers
{
    public class ServerController : Controller
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public ServerController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }


        [HttpGet]
        public IActionResult Index()
        {
            //ViewBag.NumberOfUsers = ConnectedUser.UsersId;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(Notification notification)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", notification.Message);
            // await _hubContext.Clients.User(User.Identity.Name).SendAsync("ReceiveMessage", notification.Message);
            
            return View();
        }

    }
}
