using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Competence
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Kompetens")]
        public string Name { get; set; }
        public virtual ICollection<CV> CVs { get; set; }
    }
}
