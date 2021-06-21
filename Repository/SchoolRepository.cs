using Contracts;
using Entities;
using Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SchoolRepository : RepositoryBase<School>, ISchoolRepository
    {
        public SchoolRepository(SchoolContext schoolContext) : base(schoolContext)
        {

        }
    }
}
