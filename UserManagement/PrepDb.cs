using Microsoft.EntityFrameworkCore;
using UserManagement.Data;

namespace UserManagement
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<UserDbContext>());
        }

        private static void SeedData(UserDbContext context)
        {
            Console.WriteLine("Applying Migrations...");
            context.Database.Migrate();
        }
    }
}
