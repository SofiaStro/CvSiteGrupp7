using Data.Contexts;
using Data.Models;
using Data.Repositories;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Services
{
    public class CvService
    {
        private CvDBContext db = new CvDBContext();
        private ExperienceRepository experienceRepository = new ExperienceRepository();
        private EducationRepository educationRepository = new EducationRepository();
        private CompetenceRepository competenceRepository = new CompetenceRepository();
        private readonly HttpContext _httpcontext;

        public CvService(HttpContext httpcontext)
        {
            _httpcontext = httpcontext;
        }
        public CV CreateCv(string userName)
        {
            var newCv = new CV()
            {
                UserName = userName,
                Private = true
            };
            return newCv;
        }

        public CvEditInfoView GetEditInfoView(int id)
        {
            CV cv = db.cvs.Find(id);
            var newCvView = new CvEditInfoView
            {
                Id = cv.Id,
                Name = cv.Name,
                Address = cv.Address,
                Private = cv.Private
            };
            return newCvView;
        }

        public void UpdateInfo(CvEditInfoView newCv)
        {
            var dbCv = db.cvs.FirstOrDefault(x => x.Id == newCv.Id);
            dbCv.Name = newCv.Name;
            dbCv.Address = newCv.Address;
            dbCv.Private = newCv.Private;
            db.SaveChanges();
        }

        public CvEditImgView GetEditImgView(int id)
        {
            CV cv = db.cvs.Find(id);
            var newCvView = new CvEditImgView
            {
                Id = cv.Id,
                CurrentPath = cv.ImagePath
            };
            return newCvView;
        }

        public void UpdateImg(CvEditImgView model)
        {
            var currentCv = db.cvs.FirstOrDefault(x => x.Id == model.Id);
            var filename = model.Image.FileName;
            var filepath = _httpcontext.Server.MapPath("~/UploadedImages");
            model.Image.SaveAs(filepath + "/" + filename);

            currentCv.ImagePath = filename;
            db.SaveChanges();
        }

        public CvIndexView GetCvIndexVeiw(int id)
        {
            CV cv = db.cvs.Find(id);
            var newCvView = new CvIndexView
            {
                Id = cv.Id,
                Name = cv.Name,
                Address = cv.Address,
                Private = cv.Private,
                ImagePath = cv.ImagePath,
                UserName = cv.UserName,
                ListOfExperience = experienceRepository.GetListOfExperience(cv.Id),
                ListOfEducation = educationRepository.GetListOfEducation(cv.Id),
                ListOfCompetence = competenceRepository.GetListOfCompetence(cv.Id)
            };
            return newCvView;
        }

        public IQueryable<CV> GetCvWithUserName (IQueryable<string> userNames, bool loggedIn)
        {
            List<CV> listOfCvs = new List<CV>(); 
            if(loggedIn == true)
            {
                listOfCvs = db.cvs.ToList();
            }
            else
            {
                listOfCvs = db.cvs.Where(row => row.Private == false).ToList();
            }
            List<CV> listOfCvWithUserName = new List<CV>();
            foreach(var userName in userNames)
            {
                foreach(var Cv in listOfCvs)
                {
                    if (Cv.UserName.Equals(userName))
                    {
                        listOfCvWithUserName.Add(Cv);
                    }
                }
            }
            return listOfCvWithUserName.AsQueryable();
        }
    }
}
