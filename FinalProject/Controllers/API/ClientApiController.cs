using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FinalProject.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientApiController : ControllerBase
    {

        [HttpGet]
        public IActionResult Index(string? search)
        {
            using ImageContext db = new ImageContext();
            List<ImageClass> image = db.ImagesClass.ToList<ImageClass>();

            if(search != null)
            {
                //image = image.Where(p => p.Title.ToLower().Contains(search.ToLower())).ToList();
                image = image.Where(p => p.Title.ToLower().IndexOf(search.ToLower() ) >= 0).ToList();
                                                                                 //^ si potrebbe aggiungere: , StringComparison.OrdinalIgnoreCase

            }

            return Ok(image);
        }

        [HttpGet ("{id}")]
        public IActionResult Details(int id)
        {
            using ImageContext db = new ImageContext();
            ImageClass image = db.ImagesClass
                .Include(image => image.Category)
                .FirstOrDefault(x => x.Id == id);

            return Ok(image);
        }
    }
}
