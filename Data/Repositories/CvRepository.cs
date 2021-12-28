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
            List<CV> listOfThreeRandomCV = new List<CV>();
            var random = new Random();
            if(loggedIn == true)
            {
                List<CV> listOfAllCv = db.cvs.Where(row => row.Name != null).ToList();
                if (listOfAllCv.Count() < 3)
                {
                    return listOfAllCv;
                }
                else
                {
                    int i1 = random.Next(listOfAllCv.Count);
                    int i2;
                    int i3;
                    do
                    {
                        i2 = random.Next(listOfAllCv.Count);
                        i3 = random.Next(listOfAllCv.Count);
                    } while (i2 == i1 || i2 == i3 || i3 == i1);
                    listOfThreeRandomCV.Add(listOfAllCv[i1]);
                    listOfThreeRandomCV.Add(listOfAllCv[i2]);
                    listOfThreeRandomCV.Add(listOfAllCv[i3]);
                    return listOfThreeRandomCV;
                }
            }
            else
            {
                List<CV> listOfAllPublicCv = db.cvs.Where(row => row.Private == false && row.Name != null).ToList();
                if(listOfAllPublicCv.Count < 3)
                {
                    return listOfAllPublicCv;
                }
                else
                {
                    int i1 = random.Next(listOfAllPublicCv.Count);
                    int i2;
                    int i3;
                    do
                    {
                        i2 = random.Next(listOfAllPublicCv.Count);
                        i3 = random.Next(listOfAllPublicCv.Count);
                    } while (i2 == i1 || i2 == i3 || i3 == i1);
                    listOfThreeRandomCV.Add(listOfAllPublicCv[i1]);
                    listOfThreeRandomCV.Add(listOfAllPublicCv[i2]);
                    listOfThreeRandomCV.Add(listOfAllPublicCv[i3]);
                    return listOfThreeRandomCV;
                }
            }
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
