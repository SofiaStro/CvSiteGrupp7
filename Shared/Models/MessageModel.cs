using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        [Display(Name = "Avsändare")]
        [Required]
        public string Sender { get; set; }
        [Display(Name = "Meddelande")]
        [Required]
        public string Content { get; set; }
        public bool Read { get; set; }
        [Display(Name = "Mottagare")]
        public string Receiver{ get; set; }
    }
}
