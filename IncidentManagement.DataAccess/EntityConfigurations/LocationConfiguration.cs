using IncidentManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentManagement.DataAccess.EntityConfigurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            // Property configurations
            builder.HasKey(l => new { l.Latitude, l.Longitude });
            builder.Property(l => l.Latitude)
                .IsRequired()
                .HasColumnType("float(10,6)"); // https://developers.google.com/maps/documentation/javascript/mysql-to-maps#createtable
            builder.Property(l => l.Longitude)
                .IsRequired()
                .HasColumnType("float(10,6)"); // https://developers.google.com/maps/documentation/javascript/mysql-to-maps#createtable

            // Relationship configurations
        }
    }
}
