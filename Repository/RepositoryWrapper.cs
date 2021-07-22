using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper //: IRepositoryWrapper
    {
        private SchoolContext _schoolContext;
        private SchoolRepository _schoolRepository;
        private StudenRepository _studenRepository;
        private LineNotiRepository _lineNotiRepository;

        public SchoolRepository School
        {
            get
            {
                if (_schoolRepository == null)
                {
                    _schoolRepository = new SchoolRepository(_schoolContext);
                }
                return _schoolRepository;
            }
        }

        public StudenRepository Studen
        {
            get
            {
                if (_studenRepository == null)
                {
                    _studenRepository = new StudenRepository(_schoolContext);
                }
                return _studenRepository;
            }
        }

        public LineNotiRepository LineNoti
        {
            get
            {
                if (_lineNotiRepository == null)
                {
                    _lineNotiRepository = new LineNotiRepository();
                }
                return _lineNotiRepository;
            }
        }

        public RepositoryWrapper(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public void Save()
        {
            _schoolContext.SaveChanges();
        }
    }
}
