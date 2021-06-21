using Contracts;
using Entities;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class StudenRepository : RepositoryBase<Studen>, IStudenRepository
    {
        private SchoolContext _db;
        public StudenRepository(SchoolContext schoolContext) :base(schoolContext)
        {
            _db = schoolContext;
        }

        public string GetOnce()
        {
            var result = (from s in _db.Studens
                          where s.ClassName.Contains("RoomA")
                          select s.Name).FirstOrDefault().ToString();
            return result;
        }
    }
}
