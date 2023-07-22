using Database;
using Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.GetUser;
public class Endpoint : EndpointWithoutRequest<UserResponse>
{
    public AppDbContext Db { get; set; } = null!;
    public IUserService UserService { get; set; } = null!;
    public override void Configure()
    {
        Get("/user");
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var userId = UserService.UserId;

        var user = await Db.Users
        .Select(u => new UserResponse
        {
            Email = u.Email,
            Id = u.Id,
            Name = u.Name
        }).FirstOrDefaultAsync(u => u.Id == userId, ct);

        if (user == default)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        Response = user;
    }
}
