namespace Contracts
{
    public interface IRepositoryWrapper
    {
        ISchoolRepository School { get; }
        IStudenRepository Studen { get; }
        ILineNotiRepository LineNoti { get;  }
        IUsersRepository Users { get; }
        void Save();
    }
}