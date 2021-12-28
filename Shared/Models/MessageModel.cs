using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        [Display(Name = "Avsändare")]
        public string Sender { get; set; }
        [Display(Name = "Meddelande")]
        [Required]
        public string Content { get; set; }
        public bool Read { get; set; }
        public string UserName{ get; set; }

        public int UnreadMessages { get; set; }
    }
}
