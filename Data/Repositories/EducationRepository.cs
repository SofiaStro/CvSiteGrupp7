using Data.Contexts;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EducationRepository
    {
        private CvDBContext db = new CvDBContext();

        //public List<Education> GetListOfEducation()
        //{
        //    return db.educations.ToList();
        //}
        public List<Education> GetListOfEducation(int cvId)
        {
            return db.educations.Where(x => x.CvId == cvId).ToList();
        }
    }
}
