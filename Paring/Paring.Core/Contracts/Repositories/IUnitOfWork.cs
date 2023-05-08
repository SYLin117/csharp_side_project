namespace Paring.Core.Contracts.Repositories;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }

    Task<int> SaveChangesAsync();
    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}