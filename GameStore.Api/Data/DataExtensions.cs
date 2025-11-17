using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public static class DataExtensions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using IServiceScope scope = app.Services.CreateScope();
        GameStoreContext DbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await DbContext.Database.MigrateAsync();
    }
}
