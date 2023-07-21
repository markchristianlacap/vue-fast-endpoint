using Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Database.Seeders;

public class DbSeeder
{
    private readonly AppDbContext _db;
    private readonly IUserService _userService;

    public DbSeeder(AppDbContext db, IUserService userService)
    {
        _db = db;
        _userService = userService;
    }

    public async Task Seed()
    {
        await _db.Database.MigrateAsync();
        await _db.SeedUsers(_userService);
    }
}
