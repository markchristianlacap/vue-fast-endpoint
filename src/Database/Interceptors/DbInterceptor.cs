using Database.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Database.Interceptors;

public class DbInterceptor : SaveChangesInterceptor
{
    private readonly IUserService _user;
    private readonly IDateTimeService _date;

    public DbInterceptor(IUserService user, IDateTimeService dateTime)
    {
        _user = user;
        _date = dateTime;
    }

    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result
    )
    {
        UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default
    )
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public void UpdateEntities(DbContext? context)
    {
        if (context == null)
            return;

        // created entity
        foreach (var entry in context.ChangeTracker.Entries<ICreatedEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = _date.Now;
            }
        }

        // auditable created entity
        foreach (var entry in context.ChangeTracker.Entries<ICreatedEntity<User>>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = _date.Now;
                entry.Entity.CreatedById = _user.UserId;
            }
        }

        // auditable updated entity
        foreach (var entry in context.ChangeTracker.Entries<IUpdatedEntity<User>>())
        {
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = _date.Now;
                entry.Entity.UpdatedById = _user.UserId;
            }

        }

        // updated entity
        foreach (var entry in context.ChangeTracker.Entries<IUpdatedEntity>())
        {
            if (entry.State == EntityState.Modified || entry.State == EntityState.Added)
            {
                entry.Entity.UpdatedAt = _date.Now;
            }
        }
    }
}
