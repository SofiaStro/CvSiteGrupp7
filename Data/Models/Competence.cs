using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Competence
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Kompetens")]
        public string Name { get; set; }
        [Required]
        public int CvId { get; set; }
    }
}
