using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Entities;

namespace Community.API
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using DatabaseContext dbContext =
                scope.ServiceProvider.GetRequiredService<DatabaseContext>();

            dbContext.Database.Migrate();
        }
    }
}
