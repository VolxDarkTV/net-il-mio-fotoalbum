using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                image = image.Where(p => p.Title.ToLower().Contains(search.ToLower())).ToList();
            }

            return Ok(image);
        }

    }
}
