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

        public EditExperienceView GetEditExperienceView(int id)
        {
            Experience experience = db.experiences.Find(id);
            var newExperienceView = new EditExperienceView
            {
                Id = experience.Id,
                Name = experience.Name,
            };
            return newExperienceView;
        }

        public void UpdateExperience(EditExperienceView newValue)
        {
            var dbExperience = db.experiences.FirstOrDefault(x => x.Id == newValue.Id);
            dbExperience.Name = newValue.Name;
            
            db.SaveChanges();
        }
    }
}
