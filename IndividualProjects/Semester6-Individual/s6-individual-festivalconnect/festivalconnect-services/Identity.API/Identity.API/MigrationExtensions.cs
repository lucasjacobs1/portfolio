using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Entities;

namespace Identity.API
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            try
            {
                using IServiceScope scope = app.ApplicationServices.CreateScope();

                using DatabaseContext dbContext =
                    scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                dbContext.Database.Migrate();
            }
            catch (Exception ex) { Console.WriteLine("database tables exists"); }
        }
    }
}
