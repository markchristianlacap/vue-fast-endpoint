using Database.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Database;

public static class Setup
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(
            o => o.UseSqlServer(connectionString, b => b.MigrationsAssembly("Database"))
        );
        services.AddScoped<DbInterceptor>();
    }
}
