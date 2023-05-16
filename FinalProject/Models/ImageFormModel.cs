using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Models
{
    public class ImageFormModel
    {
        public ImageClass ImagesClass { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        public List<string>? SelectedCategories { get; set; }
    }
}
