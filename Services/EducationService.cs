using Data.Contexts;
using Data.Models;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EducationService
    {
        private CvDBContext db = new CvDBContext();

        public void CreateEducation(CreateEducationView model, int cvId)
        {
            var newEducation = new Education()
            {
                Name = model.Name,
                CvId = cvId
            };
            db.educations.Add(newEducation);
            db.SaveChanges();
        }

        public void UpdateEducation(Education model)
        {
            var dbEducation = db.educations.FirstOrDefault(x => x.Id == model.Id);
            dbEducation.Name = model.Name;

            db.SaveChanges();
        }
    }
}
