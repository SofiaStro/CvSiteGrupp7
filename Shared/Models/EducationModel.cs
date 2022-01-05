using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class CreateEducationView
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Utbildning")]
        public string Name { get; set; }
        [Required]
        public int CvId { get; set; }
    }
}
