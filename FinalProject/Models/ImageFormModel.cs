using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Models
{
    public class ImageFormModel
    {
        public ImageClass ImagesClass { get; set; }
        public bool IsImagePrivate { get; set; }

        private string? _PrivateText;
        public string? PrivateText 
        {
            get 
            {
                return _PrivateText;
            }
            set 
            {
                _PrivateText = value;
                IsImagePrivate = value == "on";
            }
        }
        public List<SelectListItem>? Categories { get; set; }
        public List<string>? SelectedCategories { get; set; }
        public Message Message { get; set; }
    }
}
