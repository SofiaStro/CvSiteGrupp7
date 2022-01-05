using Data.Contexts;
using Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class CompetenceRepository
    {
        private CvDBContext db = new CvDBContext();
        public List<Competence> GetListOfCompetence(int cvId)
        {
            return db.competences.Where(x => x.CvId == cvId).ToList();
        }
    }
}
