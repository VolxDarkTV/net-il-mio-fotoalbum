using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email Invalid")]
        public string Email { get; set; }
        [Required]
        public string MessageClient { get; set; }


        public int ImageClassId { get; set; }
        public ImageClass ImageClass { get; set; }

    }
}
