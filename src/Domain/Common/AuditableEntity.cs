using Domain.Entities;

namespace Domain.Common;

public class AuditableEntity : BaseEntity
{
    public Guid? CreatedById { get; set; }
    public User? CreatedBy { get; set; }
    public Guid? UpdatedById { get; set; }
    public User? UpdatedBy { get; set; }
}
