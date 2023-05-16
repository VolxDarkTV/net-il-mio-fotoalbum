using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
