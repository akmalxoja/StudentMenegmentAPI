using Microsoft.EntityFrameworkCore;
using Permission_Domen.Entityes;
using VehicleManagement_Application.Abstractions;
using VehicleManagement_Domen.Entityes;

namespace VehicleManagement_Infrastructure
{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Students> Students { get; set; }

        public async ValueTask<int> SaveChanges(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
