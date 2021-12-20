using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class MessageCreate
    {
        public string Sender { get; set; }
        public string Content { get; set; } 
       // public DateTime SendDate { get; set; }
       // public bool Read { get; set; }
       public string UserName{ get; set; }
    }
}
