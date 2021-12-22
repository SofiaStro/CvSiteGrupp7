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
        private readonly CvDBContext _context;

        public CvRepository(CvDBContext context)
        {
            _context = context;
        }

        public CV GetCv(int id)
        {
            return _context.cvs.FirstOrDefault(x => x.Id == id);
        }

        public CV SaveCv(CV cv)
        {
            if (cv.Id != 0)
            { //om har fått ett id, då finns boken redan, vi ska spara det som ändrats.
                _context.Entry(cv).State = EntityState.Modified; // vi säger åt EF att denna boken med dess [Key] att vi vill spara om alla fält
            }
            else
            {
                _context.cvs.Add(cv);
            }

            _context.SaveChanges();
            return cv;

        }
    }
}
