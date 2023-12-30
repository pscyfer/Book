using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Book.Infrastructure;

public static class DatabaseContextSeed
{
    public static async Task MigrateSeedAsync(IServiceProvider services)
    {
        var context = services.GetRequiredService<DataContext>();

        var userManager = services.GetRequiredService<UserManager<User>>();

        await SeedDatabaseAsync(context, userManager);
    }

    private static async Task SeedDatabaseAsync(DataContext context, UserManager<User> userManager)
    {
        if (!userManager.Users.Any())
        {
            var user = new User { UserName = "Owner", Email = "admin@admin.com", EmailConfirmed = true };

            await userManager.CreateAsync(user, "owner123");
        }

        await context.SaveChangesAsync();
    }
}
