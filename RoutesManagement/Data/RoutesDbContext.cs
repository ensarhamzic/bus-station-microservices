using Microsoft.EntityFrameworkCore;
using RoutesManagement.Data.Models;

namespace RoutesManagement.Data
{
    public class RoutesDbContext : DbContext
    {
        public RoutesDbContext(DbContextOptions<RoutesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Route>()
                .HasOne(r => r.FromLocation)
                .WithMany(l => l.RoutesFromLocation)
                .HasForeignKey(r => r.FromLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Models.Route>()
                .HasOne(r => r.ToLocation)
                .WithMany(l => l.RoutesToLocation)
                .HasForeignKey(r => r.ToLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Bus> Buses { get; set; } = default!;
        public DbSet<Location> Locations { get; set; } = default!;
        public DbSet<Models.Route> Routes { get; set; } = default!;
    }
}
