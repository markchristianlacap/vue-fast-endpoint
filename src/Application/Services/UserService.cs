using System.Security.Claims;
using Database;
using Database.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _http;

    public UserService(IHttpContextAccessor http)
    {
        _http = http;
    }

    public Guid? UserId =>
        Guid.TryParse(
            _http.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier),
            out var id
        )
            ? id
            : null;

    public User HashPassword(User user, string password)
    {
        user.HashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        return user;
    }

    public bool VerifyPassword(User user, string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, user.HashedPassword);
    }
}
