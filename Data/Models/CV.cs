using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class CV
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "CV")]
        public string Name { get; set; }
        [Required]
        public  string Address { get; set; }
        [Required]
        public bool Private { get; set; }

        public virtual ICollection<Competence> Comptetences { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Competence> Competences { get; set; }
    }
}
