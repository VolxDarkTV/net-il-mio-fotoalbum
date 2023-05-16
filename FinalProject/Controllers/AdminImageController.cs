using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FinalProject.Controllers
{
    public class AdminImageController : Controller
    {
        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult Index()
        {
            using ImageContext db = new ImageContext();
            List<ImageClass> image = db.ImagesClass.ToList<ImageClass>();

            return View(image);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            using ImageContext db = new ImageContext();
            ImageClass image = db.ImagesClass
                .Include(image => image.Category)
                .FirstOrDefault(x => x.Id == id);

            return View("Details", image);
        }

        [HttpGet]
        public IActionResult Create()
        {
            using ImageContext db = new ImageContext();
            List<Category> categories = db.Category.ToList<Category>();

            ImageFormModel model = new ImageFormModel();
            model.ImagesClass = new ImageClass();
            model.Categories = categories;

            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Create(ImageFormModel data) 
        {
            if (!ModelState.IsValid)
            {
                using ImageContext context = new ImageContext();
                List<Category> category = context.Category.ToList<Category>();
                data.Categories = category;

                return View("Create", data);
            }

            using ImageContext db = new ImageContext();
            ImageClass imageClassToCreate = new ImageClass();
            imageClassToCreate.Title = data.ImagesClass.Title;
            imageClassToCreate.Description = data.ImagesClass.Description;
            imageClassToCreate.Img = data.ImagesClass.Img;
            imageClassToCreate.Visible = data.ImagesClass.Visible;
            imageClassToCreate.Category = data.ImagesClass.Category;

            db.ImagesClass.Add(imageClassToCreate);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
