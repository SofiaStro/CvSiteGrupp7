using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey("ApplicationUser")]
        //public int UserID { get; set; }
        //public virtual ApplicationUser User { get; set; }

    }
}
