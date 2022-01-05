using Data.Contexts;
using Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class ExperienceRepository
    {
        private CvDBContext db = new CvDBContext();
        public List<Experience> GetListOfExperiences(int cvId)
        {
            return db.experiences.Where(x => x.CvId == cvId).ToList();
        }
    }
}
