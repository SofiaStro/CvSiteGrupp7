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
        [Display(Name= "Ingår i projekt")]
        public string UserName { get; set; }
        public int ProjectId { get; set; }
        public string UserId { get; set; }
    }
}
