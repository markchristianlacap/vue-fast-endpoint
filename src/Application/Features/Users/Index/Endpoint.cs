using Database;

namespace Application.Features.Users.Index;

public class Endpoint : Endpoint<UserPagedRequest, PagedResponse<UserPagedModel>>
{
    public AppDbContext Db { get; set; } = null!;

    public override void Configure()
    {
        Get("/users");
    }

    public override async Task HandleAsync(UserPagedRequest req, CancellationToken ct)
    {
        var query = Db.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(req.Search))
        {
            query = query.Where(x => x.Name.Contains(req.Search) || x.Email.Contains(req.Search));
        }

        Response = await query
            .Select(
                u =>
                    new UserPagedModel
                    {
                        CreatedAt = u.CreatedAt,
                        Email = u.Email,
                        Id = u.Id,
                        Name = u.Name
                    }
            )
            .ToPagedAsync(req, ct);
    }
}
