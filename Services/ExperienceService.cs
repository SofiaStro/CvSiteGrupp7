using Data.Contexts;
using Data.Models;
using Shared.Models;
using System.Linq;

namespace Services
{
    public class ExperienceService 
    {
        private CvDBContext db = new CvDBContext();

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

        public void UpdateExperience(Experience model)
        {
            var dbExperience = db.experiences.FirstOrDefault(x => x.Id == model.Id);
            dbExperience.Name = model.Name;

            db.SaveChanges();
        }
    }
}
