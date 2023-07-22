using Database.Interfaces;
using Domain.Entities;

namespace Database.Seeders;

public static class UsersSeeder
{
    public static async Task SeedUsers(this AppDbContext db, IUserService userService)
    {
        if (db.Users.Any())
        {
            return;
        }
        var user = new User { Name = "Admin", Email = "admin@admin.com", };
        user = userService.HashPassword(user, "admin");
        await db.Users.AddAsync(user);
        await db.SaveChangesAsync();
    }
}
