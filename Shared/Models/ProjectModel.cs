using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Contexts;
using Data.Models;

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
        //[Display(Name = "Ingår i projekt")]
        //public int[] UserInProject { get; set; }
    }


}
