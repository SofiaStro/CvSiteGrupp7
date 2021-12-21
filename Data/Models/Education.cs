using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Utbildning")]
        public string Name { get; set; }

    }
}
