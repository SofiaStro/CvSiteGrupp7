using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Contexts;

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
        [Display(Name = "Ingår i projekt")]
        public List<ApplicationUser> UserInProject { get; set; } = new List<ApplicationUser>();
    }
}
