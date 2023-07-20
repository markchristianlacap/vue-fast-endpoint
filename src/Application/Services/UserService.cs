using Database.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class UserService : IUserService
{
    Guid? IUserService.UserId => throw new NotImplementedException();

    Task<User> IUserService.CreateUser(User user, string password) =>
        throw new NotImplementedException();

    Task IUserService.ForgotPassword(string email, string callBackUrl) =>
        throw new NotImplementedException();

    Task IUserService.ResetPassword(string token, string password) =>
        throw new NotImplementedException();

    Task IUserService.SendEmailVerification(User user) => throw new NotImplementedException();

    User IUserService.UpdateUserPassword(User user, string password) =>
        throw new NotImplementedException();

    Task IUserService.VerifyEmail(string token) => throw new NotImplementedException();

    bool IUserService.VerifyPassword(string hashPassword, string password) =>
        throw new NotImplementedException();
}
