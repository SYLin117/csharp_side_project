using Infrastructure.Repositories;
using Paring.Core.Contracts.Repositories;
using Paring.Core.Entities;
using Paring.Infra.Data;

namespace Paring.Infra.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ParingDbContext context) : base(context)
    {
    }
}