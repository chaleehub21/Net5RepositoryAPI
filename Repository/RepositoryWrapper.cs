using Contracts;
using Entities;
using Entities.Helper;
using Microsoft.Extensions.Options;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private SchoolContext _schoolContext;
        private readonly AppSettings _appSettings;
        private ISchoolRepository _schoolRepository;
        private IStudenRepository _studenRepository;
        private ILineNotiRepository _lineNotiRepository;
        private IUsersRepository _usersRepository;

        public ISchoolRepository School
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

        public IStudenRepository Studen
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

        public ILineNotiRepository LineNoti
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

        public IUsersRepository Users
        {
            get
            {
                if (_usersRepository == null)
                {
                    _usersRepository = new UserRepository(_schoolContext,_appSettings);
                }
                return _usersRepository;
            }
        }

        public RepositoryWrapper(SchoolContext schoolContext, IOptions<AppSettings> appSettings)
        {
            _schoolContext = schoolContext;
            _appSettings = appSettings.Value;
        }

        public void Save()
        {
            _schoolContext.SaveChanges();
        }
    }
}
