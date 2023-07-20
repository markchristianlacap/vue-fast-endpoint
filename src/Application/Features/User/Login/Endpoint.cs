using Database;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Login;

public class Endpoint : Endpoint<LoginRequest>
{
    public AppDbContext Db { get; set; } = null!;

    public override void Configure()
    {
        AllowAnonymous();
        Post("/login");
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        var user = await Db.Users.FirstOrDefaultAsync(x => x.Email == req.Email, ct);
        if (user == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
    }
}
