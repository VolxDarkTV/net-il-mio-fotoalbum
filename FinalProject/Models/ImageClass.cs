using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class ImageClass
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il Titolo è obbligatorio")]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "L'immagine è obbligatoria ;)")]
        public string Img { get; set; }

        [DefaultValue(true)]
        public bool Visible { get; set; }


        public Category? Category { get; set; }



        public ImageClass()
        {

        }
        public ImageClass(string title, string description, string img, bool visible)
        {
            Title = title;
            Description = description;
            Img = img;
            Visible = visible;
        }
    }
}
