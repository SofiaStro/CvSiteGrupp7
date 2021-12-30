using Data.Contexts;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CvRepository
    {
        private CvDBContext db = new CvDBContext();
        public List<CV> GetListOfCvs(bool loggedIn)
        {
            if(loggedIn == true)
            {
                List<CV> listOfAllCv = db.cvs.ToList();
                if (listOfAllCv.Count < 3)
                {
                    return listOfAllCv;
                }
                else
                {
                    return insertRandomCvs(listOfAllCv);
                }
            }
            else
            {
                List<CV> listOfAllPublicCv = db.cvs.Where(row => row.Private == false).ToList();
                if(listOfAllPublicCv.Count < 3)
                {
                    return listOfAllPublicCv;
                }
                else
                {
                    return insertRandomCvs(listOfAllPublicCv);
                }
            }
        }

        public List<CV> insertRandomCvs(List<CV> listOfCv)
        {
            var random = new Random();
            List<CV> listOfThreeRandomCV = new List<CV>();
            int i1 = random.Next(listOfCv.Count);
            int i2;
            int i3;
            do
            {
                i2 = random.Next(listOfCv.Count);
                i3 = random.Next(listOfCv.Count);
            } while (i2 == i1 || i2 == i3 || i3 == i1);
            listOfThreeRandomCV.Add(listOfCv[i1]);
            listOfThreeRandomCV.Add(listOfCv[i2]);
            listOfThreeRandomCV.Add(listOfCv[i3]);
            return listOfThreeRandomCV;
        }

        //private readonly CvDBContext _context;

        //public CvRepository(CvDBContext context)
        //{
        //    _context = context;
        //}

        //public CV GetCv(int id)
        //{
        //    return _context.cvs.FirstOrDefault(x => x.Id == id);
        //}

        //public CV SaveCv(CV cv)
        //{
        //    if (cv.Id != 0)
        //    {
        //        _context.Entry(cv).State = EntityState.Modified;
        //    }
        //    else
        //    {
        //        _context.cvs.Add(cv);
        //    }

        //    _context.SaveChanges();
        //    return cv;

        //}
    }
}
