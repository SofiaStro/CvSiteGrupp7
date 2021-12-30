using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Project
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
        //[Key]
        //[Column(Order = 2)]
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
