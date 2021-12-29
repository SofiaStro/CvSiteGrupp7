using Data.Models;
using System.Collections.Generic;

namespace Shared.Models
{
    public class HomeViewModel
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public List<CV> ListOfCvs { get; set; }
    }
}
