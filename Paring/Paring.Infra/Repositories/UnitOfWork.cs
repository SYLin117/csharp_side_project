using Microsoft.EntityFrameworkCore.Storage;
using Paring.Core.Contracts.Repositories;
using Paring.Infra.Data;

namespace Paring.Infra.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ParingDbContext _dbContext;
    private IDbContextTransaction _transaction;
    private bool _disposed;
    public IUserRepository UserRepository { get; }


    public UnitOfWork(ParingDbContext dbContext, IUserRepository userRepository)
    {
        _dbContext = dbContext;
        UserRepository = userRepository;
    }


    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void BeginTransaction()
    {
        _transaction = _dbContext.Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
        _transaction?.Commit();
        _transaction = null;
    }

    public void RollbackTransaction()
    {
        _transaction?.Rollback();
        _transaction = null;
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _dbContext.Dispose();
    }
}