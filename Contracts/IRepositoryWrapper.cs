using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        ISchoolRepository School { get; }
        IStudenRepository Studen { get; }
        void Save();
    }
}
