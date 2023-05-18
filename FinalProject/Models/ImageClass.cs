using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public bool IsPrivate { get; set; }

        public List<Category>? Category { get; set; }


        //Message
        public List<Message> Message { get; set; }


        public ImageClass()
        {

        }
        public ImageClass(string title, string description, string img, bool isPrivate)
        {
            Title = title;
            Description = description;
            Img = img;
            IsPrivate = isPrivate;
        }
    }
}
