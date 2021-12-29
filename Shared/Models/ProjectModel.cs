using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class ProjectCreateModel
    {
        [Required]
        [Display(Name = "Projektnamn")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }
    }
}
