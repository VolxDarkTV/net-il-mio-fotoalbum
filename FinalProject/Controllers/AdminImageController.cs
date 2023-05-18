using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Data;

namespace FinalProject.Controllers
{
    public class AdminImageController : Controller
    {
        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult Index(string? search)
        {
            using ImageContext db = new ImageContext();
            List<ImageClass> image = db.ImagesClass.ToList<ImageClass>();
            
            if (search != null)
            {
                //image = image.Where(p => p.Title.ToLower().Contains(search.ToLower())).ToList();
                image = image.Where(p => p.Title.ToLower().IndexOf(search.ToLower() ) >= 0).ToList();
                                                                                 //^ si potrebbe aggiungere: , StringComparison.OrdinalIgnoreCase
            }

            return View(image);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            using ImageContext db = new ImageContext();
            ImageClass image = db.ImagesClass
                .Include(image => image.Category)
                .FirstOrDefault(x => x.Id == id);

            return View("Show", image);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult Create()
        {
            using ImageContext db = new ImageContext();

            ImageFormModel model = new ImageFormModel();
            model.ImagesClass = new ImageClass();

            List<Category> categories = db.Category.ToList<Category>();
            List<SelectListItem> listCategories = new List<SelectListItem>();

            foreach (Category category in categories)
            {
                listCategories.Add(
                    new SelectListItem()
                    {
                        Text = category.Name,
                        Value = category.Id.ToString()
                    }
                );
            }
            
            model.Categories = listCategories;
            
            return View("Create", model);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult Create(ImageFormModel data) 
        {
            if (!ModelState.IsValid)
            {
                using ImageContext context = new ImageContext();

                List<Category> categories = context.Category.ToList<Category>();
                List<SelectListItem> listCategories = new List<SelectListItem>();

                foreach (Category category in categories)
                {
                    listCategories.Add(
                            new SelectListItem
                            {
                                Text = category.Name,
                                Value = category.Id.ToString()
                            }
                        );
                }

                data.Categories = listCategories;

                return View("Create", data);
            }

            using ImageContext db = new ImageContext();

            ImageClass imageClassToCreate = new ImageClass();
            imageClassToCreate.Category = new List<Category>();
            imageClassToCreate.Title = data.ImagesClass.Title;
            imageClassToCreate.Description = data.ImagesClass.Description;
            imageClassToCreate.Img = data.ImagesClass.Img;
            imageClassToCreate.IsPrivate = data.IsImagePrivate;

            if(data.SelectedCategories != null)
            {
                foreach(string selectedIntCategories in data.SelectedCategories)
                {
                    int selectIntCategories = int.Parse(selectedIntCategories);
                    Category category = db.Category.FirstOrDefault(m => m.Id == selectIntCategories);
                    imageClassToCreate.Category.Add(category);
                }
            }

            db.ImagesClass.Add(imageClassToCreate);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            using ImageContext db = new ImageContext();
            ImageClass imageEdit = db.ImagesClass.Include(p => p.Category).FirstOrDefault(image => image.Id == Id);
            if(imageEdit == null) 
            {
                return NotFound();
            }
            else
            {
                ImageFormModel model = new ImageFormModel();
                model.ImagesClass = imageEdit;
                model.SelectedCategories = new List<string>();

                foreach(var category in imageEdit.Category)
                {
                    model.SelectedCategories.Add(category.Id.ToString());
                }

                List<Category> categories = db.Category.ToList();
                List<SelectListItem> listCategories = new List<SelectListItem>();
                foreach(var category in categories)
                {
                    listCategories.Add(
                        new SelectListItem
                        {
                            Text = category.Name,
                            Value = category.Id.ToString(),
                            Selected = imageEdit.Category.Any(m => m.Id == category.Id)
                        }
                    );
                }

                model.Categories = listCategories;

                return View(model);
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult Edit(int Id, ImageFormModel data) 
        {
            if (!ModelState.IsValid)
            {
                using ImageContext context = new ImageContext();
                List<Category> categories = context.Category.ToList();
                List<SelectListItem> listCategories = new List<SelectListItem>();
                foreach(var category in categories)
                {
                    listCategories.Add(
                        new SelectListItem
                        {
                            Text = category.Name,
                            Value = category.Id.ToString(),
                        }
                    );
                }

                data.Categories = listCategories;

                return View("Edit", data);
            }

            using ImageContext db = new ImageContext();
            ImageClass imageEdit = db.ImagesClass.Include(p => p.Category).FirstOrDefault(m => m.Id == Id);

            imageEdit.Category.Clear();

            if(imageEdit != null)
            {
                imageEdit.Title = data.ImagesClass.Title;
                imageEdit.Description = data.ImagesClass.Description;
                imageEdit.Img = data.ImagesClass.Img;
                imageEdit.IsPrivate = data.IsImagePrivate;

                if(data.SelectedCategories != null)
                {
                    foreach(string selectedCategory in data.SelectedCategories)
                    {
                        int selectCategory = int.Parse(selectedCategory);
                        Category category = db.Category
                            .Where(m => m.Id == selectCategory)
                            .FirstOrDefault();
                       imageEdit.Category.Add(category);
                    }
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult Delete(int id)
        {
            using ImageContext db = new ImageContext();
            ImageClass imageToDelete = db.ImagesClass.Where(m => m.Id == id).FirstOrDefault();

            if(imageToDelete != null)
            {
                db.ImagesClass.Remove(imageToDelete);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
