using Data.Contexts;
using Data.Models;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Services
{
    public class ExperienceService 
    {
        private readonly HttpContext _httpcontext;
        private CvDBContext db = new CvDBContext();

        public ExperienceService(HttpContext httpcontext)
        {
            _httpcontext = httpcontext;
        }

        public void CreateExperience(CreateExperienceView model, int cvId)
        {
            var newExperience = new Experience()
            {
                Name = model.Name,
                CvId = cvId
            };
            db.experiences.Add(newExperience);
            db.SaveChanges();
        }
    }
}
