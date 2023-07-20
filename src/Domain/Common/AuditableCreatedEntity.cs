using Domain.Entities;

namespace Domain.Common;

public class AuditableCreatedEntity : CreatedEntity
{
    public Guid? CreatedById { get; set; }
    public User? CreatedBy { get; set; }
}
