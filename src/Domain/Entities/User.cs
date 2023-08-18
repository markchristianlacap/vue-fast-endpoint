using Domain.Interfaces;

namespace Domain.Entities;

public class User : ICreatedEntity, IUpdatedEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string HashedPassword { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
