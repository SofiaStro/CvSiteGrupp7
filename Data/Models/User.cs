using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User
    { 
        [Key]
        public string UserName { get; set; }
        public User(string userName)
        {
            UserName = userName;
        }
       
    }
}
