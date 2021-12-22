using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Shared.Models
{
    public class CvEditImgView
    {
        public int Id { get; set; }
        public string CurrentPath { get; set; }
        public HttpPostedFileBase Image { get; set; }
    }
}
