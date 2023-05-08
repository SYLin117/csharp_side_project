using Microsoft.EntityFrameworkCore;
using Paring.Core.Entities;

namespace Paring.Infra.Data;

public class ParingDbContext : DbContext
{
    public ParingDbContext(DbContextOptions<ParingDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}