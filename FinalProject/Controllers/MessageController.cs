using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToRoute(new { controller = "AdminImage", action = "Index" });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ImageFormModel data)
        {
            //ModelState.Remove("Message.ImageClass");
            if (!ModelState.IsValid)
            {
                using ImageContext context = new ImageContext();

                List<Message> messages = new List<Message>();

                return RedirectToRoute(new { controller = "AdminImage", action = "Index" });
            }

            using ImageContext db = new ImageContext();

            Message messageToCreate = new Message();
            messageToCreate.Email = data.Message.Email;
            messageToCreate.MessageClient = data.Message.MessageClient;

            db.Message.Add(messageToCreate);
            db.SaveChanges();

            return RedirectToRoute(new { controller = "AdminImage", action = "Index" });
        }
    }
}
