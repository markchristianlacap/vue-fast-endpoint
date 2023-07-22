using FastEndpoints.Security;

namespace Application.Features.User.Logout;

public class Endpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Post("/user/logout");
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        await CookieAuth.SignOutAsync();
    }
}
