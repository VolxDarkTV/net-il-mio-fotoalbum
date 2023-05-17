using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            //using ImageContext db = new ImageContext();
            //ImageClass image = db.ImagesClass
            //    .Include(image => image.Category)
            //    .FirstOrDefault(x => x.Id == id);

            return View();
        }
    }
}
