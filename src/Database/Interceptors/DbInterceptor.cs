using Database.Interfaces;
using Domain.Common;
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
		// base entity
		foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
		{
			if (entry.State == EntityState.Added)
			{
				entry.Entity.CreatedAt = _date.Now;
			}
			else if (entry.State == EntityState.Modified)
			{
				entry.Entity.UpdatedAt = _date.Now;
			}
		}

		// audit entity
		foreach (var entry in context.ChangeTracker.Entries<AuditableEntity>())
		{
			if (entry.State == EntityState.Added)
			{
				entry.Entity.CreatedAt = _date.Now;
				entry.Entity.CreatedById = _user.UserId;
			}
			else if (entry.State == EntityState.Modified)
			{
				entry.Entity.UpdatedAt = _date.Now;
				entry.Entity.UpdatedById = _user.UserId;
			}
		}

		// created entity
		foreach (var entry in context.ChangeTracker.Entries<CreatedEntity>())
		{
			if (entry.State == EntityState.Added)
			{
				entry.Entity.CreatedAt = _date.Now;
			}
		}

		// auditable created entity
		foreach (var entry in context.ChangeTracker.Entries<AuditableCreatedEntity>())
		{
			if (entry.State == EntityState.Added)
			{
				entry.Entity.CreatedAt = _date.Now;
				entry.Entity.CreatedById = _user.UserId;
			}
		}
	}
}
