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

    public User CreateUser(User user, string password)
    {
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        return user;
    }

    public bool VerifyPassword(string hashPassword, string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashPassword);
    }
}
