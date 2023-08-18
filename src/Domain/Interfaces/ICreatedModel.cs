namespace Domain.Interfaces;
public interface ICreatedEntity
{
    DateTime CreatedAt { get; set; }
}

public interface ICreatedEntity<T> : ICreatedEntity
{
    Guid? CreatedById { get; set; }
    T? CreatedBy { get; set; }
}
public interface ICreatedEntity<T, TId> : ICreatedEntity<T>
{
    new TId? CreatedById { get; set; }
}
