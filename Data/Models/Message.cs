using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Avsändare")]
        public string Sender { get; set; }
        [Display(Name = "Datum")]
        public DateTime SendDate { get; set; }

        [Display(Name = "Läst")]
        public bool Read { get; set; }
        [Required]
        [Display(Name = "Meddelande")]
        public string Content { get; set; }
        public string Receiver { get; set; }

    }
}
