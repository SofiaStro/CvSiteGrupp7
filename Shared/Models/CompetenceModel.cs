using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class CreateCompetenceView
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Kompetens")]
        public string Name { get; set; }
        [Required]
        public int CvId { get; set; }
    }
}
