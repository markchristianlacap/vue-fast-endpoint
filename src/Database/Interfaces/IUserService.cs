using Domain.Entities;

namespace Database.Interfaces;

public interface IUserService
{
    Guid? UserId { get; }
    User HashPassword(User user, string password);
    bool VerifyPassword(User user, string password);
}
