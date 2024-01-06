using Microsoft.EntityFrameworkCore;
using RoutesManagement.Data;

namespace RoutesManagement
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<RoutesDbContext>());
        }

        private static void SeedData(RoutesDbContext context)
        {
            Console.WriteLine("Applying Migrations...");
            context.Database.Migrate();
        }
    }
}
