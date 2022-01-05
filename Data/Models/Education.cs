using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Utbildning")]
        public string Name { get; set; }
        [Required]
        public int CvId { get; set; }

    }
}
