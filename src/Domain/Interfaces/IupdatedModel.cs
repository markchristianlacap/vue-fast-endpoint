namespace Domain.Interfaces;
public interface IUpdatedEntity
{
    DateTime? UpdatedAt { get; set; }
}

public interface IUpdatedEntity<T> : IUpdatedEntity
{
    Guid? UpdatedById { get; set; }
    T? UpdatedBy { get; set; }
}
public interface IUpdatedEntity<T, TId> : IUpdatedEntity<T>
{
    new TId? UpdatedById { get; set; }
}
