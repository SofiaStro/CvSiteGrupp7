using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Projektnamn")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        public DateTime AddedDate{ get; set; }
        [Required]
        public string UserName { get; set; }

    }
}
