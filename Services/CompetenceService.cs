using Data.Contexts;
using Data.Models;
using Shared.Models;
using System.Linq;

namespace Services
{
    public class CompetenceService
    {
        private CvDBContext db = new CvDBContext();

        public void CreateCompetence(CreateCompetenceView model, int cvId)
        {
            var newCompetence = new Competence()
            {
                Name = model.Name,
                CvId = cvId
            };
            db.competences.Add(newCompetence);
            db.SaveChanges();
        }

        public void UpdateCompetence(Competence model)
        {
            var dbCompetence = db.competences.FirstOrDefault(x => x.Id == model.Id);
            dbCompetence.Name = model.Name;

            db.SaveChanges();
        }
    }
}
