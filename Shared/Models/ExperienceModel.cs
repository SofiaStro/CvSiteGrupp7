using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class CreateExperienceView
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Erfarenhet")]
        public string Name { get; set; }
        [Required]
        public int CvId { get; set; }
    }
}
