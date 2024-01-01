using Microsoft.AspNetCore.Mvc;

namespace SignalR.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
