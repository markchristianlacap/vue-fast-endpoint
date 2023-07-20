namespace Application.Features.User.Login;

public class Validator : Validator<LoginRequest>
{
    public Validator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}
