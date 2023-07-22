using Database;

namespace Application.Features.Users.Index;

public class UserPagedRequest : PagedRequest
{
    public string? Search { get; set; }
}

public class UserPagedModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}
