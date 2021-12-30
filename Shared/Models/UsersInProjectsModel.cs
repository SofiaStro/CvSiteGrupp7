using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class UsersInProjectsModel
    {
        [Display(Name = "Ingår i projekt")]
        public string UserName { get; set; }
        public int ProjectId { get; set; }
        public string UserId { get; set; }
    }

    public class DelecteUsersInProjectsView
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Projektnamn")]
        public string Name { get; set; }
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }
    }
}
