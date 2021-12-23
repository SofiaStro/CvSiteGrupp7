using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Services
{
    public class ProjectService
    {
        private readonly HttpContext _httpcontext;
        public ProjectService(HttpContext httpcontext)
        {
            _httpcontext = httpcontext;
        }
    }
}
