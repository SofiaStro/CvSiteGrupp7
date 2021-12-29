using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class ProjectCreateModel
    {
        [Display(Name = "Projektnamn")]
        public string Name { get; set; }
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }
    }
}
