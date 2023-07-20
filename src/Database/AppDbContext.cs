using System.Reflection;
using Database.Interceptors;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class AppDbContext : DbContext
{
    private readonly DbInterceptor _dbInterceptor;

    public AppDbContext(DbContextOptions<AppDbContext> options, DbInterceptor dbInterceptor)
        : base(options)
    {
        _dbInterceptor = dbInterceptor;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_dbInterceptor);
    }

    public DbSet<User> Users { get; set; } = null!;
}
