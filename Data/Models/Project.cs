using Data.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AddedDate{ get; set; }
        [Display(Name = "Ingår i projekt")]
        public List<ApplicationUser> UserInProject { get; set; }
        [Required]
        public string UserName { get; set; }

    }
}
