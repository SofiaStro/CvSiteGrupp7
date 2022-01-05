using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Erfarenhet")]
        public string Name { get; set; }
        [Required]
        public int CvId { get; set; }

    }
}
