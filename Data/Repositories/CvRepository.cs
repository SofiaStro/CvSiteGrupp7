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
                return db.cvs.ToList();
            }
            else
            {
                return db.cvs.Where(row => row.Private == false).ToList();
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
