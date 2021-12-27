using Data.Contexts;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CompetenceRepository
    {
        private CvDBContext db = new CvDBContext();

        //public List<Experience> GetListOfExperience()
        //{
        //    return db.experiences.ToList();
        //}
        public List<Competence> GetListOfCompetence(int cvId)
        {
            return db.competences.Where(x => x.CvId == cvId).ToList();
        }
    }
}
