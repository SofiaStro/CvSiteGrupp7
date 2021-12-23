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
