using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class HomeViewModel
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public List<CV> ListOfCvs { get; set; }
    }
}
