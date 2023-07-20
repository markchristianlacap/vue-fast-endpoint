using Domain.Entities;

namespace Database.Interfaces;

public interface IUserService
{
    Guid? UserId { get; }
    Task<User> CreateUser(User user, string password);
    User UpdateUserPassword(User user, string password);
    bool VerifyPassword(string hashPassword, string password);
    Task ForgotPassword(string email, string callBackUrl);
    Task ResetPassword(string token, string password);
    Task SendEmailVerification(User user);
    Task VerifyEmail(string token);
}
