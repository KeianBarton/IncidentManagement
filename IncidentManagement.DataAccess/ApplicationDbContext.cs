using IncidentManagement.DataAccess.Entities;
using IncidentManagement.DataAccess.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace IncidentManagement.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite
            (
                "Data Source=incidentmanagement.db",
                builder => builder.MigrationsAssembly("IncidentManagement.DataAccess")
            );
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new IncidentConfiguration());
            builder.ApplyConfiguration(new LocationConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
