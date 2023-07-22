using System.Security.Claims;
using Database;
using Database.Interfaces;
using FastEndpoints.Security;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Login;

public class Endpoint : Endpoint<LoginRequest>
{
    public AppDbContext Db { get; set; } = null!;
    public IUserService UserService { get; set; } = null!;

    public override void Configure()
    {
        AllowAnonymous();
        Post("/user/login");
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        var user = await Db.Users.FirstOrDefaultAsync(x => x.Email == req.Email, ct);

        if (user == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        if (!UserService.VerifyPassword(user, req.Password))
        {
            ThrowError("Invalid password");
            return;
        }

        // login using cookie
        await CookieAuth.SignInAsync(u =>
        {
            u.Claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        });
    }
}
