using IncidentManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentManagement.DataAccess.EntityConfigurations
{
    public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            // Property configurations
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Title)
                .IsRequired()
                .HasMaxLength(64);
            builder.Property(i => i.Description);
                //.HasColumnType("nvarchar(max)"); SQL Server
            builder.Property(i => i.Occurrence)
                .IsRequired();

            // Relationship configurations
            builder.HasOne(i => i.Location)
                .WithMany(l => l.Incidents)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
