using Microsoft.AspNetCore.Authentication.Cookies;

namespace Application.Extensions;

public static class AuthExtension
{
    public static void AddAuthExtension(this IServiceCollection services)
    {
        var scheme = CookieAuthenticationDefaults.AuthenticationScheme;
        services
            .AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = scheme;
                o.DefaultChallengeScheme = scheme;
            })
            .AddCookie(o =>
            {
                o.Cookie.SameSite = SameSiteMode.Strict;
                o.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                o.Cookie.HttpOnly = true;
                o.LoginPath = "/";
                o.AccessDeniedPath = "/";
                o.LogoutPath = "/";
                o.SlidingExpiration = true;
                o.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            });
    }
}
