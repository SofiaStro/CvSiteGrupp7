using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class CV
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Namn")]
        public string Name { get; set; }

        [Display(Name = "Adress")]
        public  string Address { get; set; }
        [Required]
        [Display(Name = "Privat sida")]
        public bool Private { get; set; }
        [Display(Name = "Personlig bild")]
        public string ImagePath { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string UserName { get; set; }
    }
}
