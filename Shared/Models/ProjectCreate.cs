using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class ProjectCreate
    {
        [Display(Name = "Projektnamn")]
        public string Name { get; set; }
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
        [Display(Name = "Datum")]
        public DateTime AddedDate { get; set; }
    }
}
