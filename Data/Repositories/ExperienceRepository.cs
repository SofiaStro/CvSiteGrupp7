using Data.Contexts;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ExperienceRepository
    {
        private CvDBContext db = new CvDBContext();

        //public List<Experience> GetListOfExperience()
        //{
        //    return db.experiences.ToList();
        //}
        public List<Experience> GetListOfExperiences(int cvId)
        {
            return db.experiences.Where(x => x.CvId == cvId).ToList();
        }
    }
}
