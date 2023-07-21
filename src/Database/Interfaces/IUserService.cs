using Domain.Entities;

namespace Database.Interfaces;

public interface IUserService
{
    Guid? UserId { get; }
    User CreateUser(User user, string password);
    bool VerifyPassword(string hashPassword, string password);
}
