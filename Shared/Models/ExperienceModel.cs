using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class CreateExperience
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Erfarenhet")]
        public string Name { get; set; }
    }
    //public class ListOfExperience
    //{
    //    public int Id { get; set; }
    //    [Required]
    //    [Display(Name = "Erfarenhet")]
    //    public string Name { get; set; }
    //}
}
