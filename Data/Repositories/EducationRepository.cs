using Data.Contexts;
using Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class EducationRepository
    {
        private CvDBContext db = new CvDBContext();
        public List<Education> GetListOfEducations(int cvId)
        {
            return db.educations.Where(x => x.CvId == cvId).ToList();
        }

    }
}
