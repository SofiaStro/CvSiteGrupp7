﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool Private { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public string UserName { get; set; }

        // public virtual ICollection<Project> Projects { get; set; }
    }
}
