using IncidentManagement.DataAccess;
using IncidentManagement.DataAccess.Entities;
using IncidentManagement.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IncidentManagement.Services.DataAccessQueries
{
    public class IncidentQueries : IIncidentQueries
    {
        private readonly ApplicationDbContext _context;

        public IncidentQueries(ApplicationDbContext context) => _context = context;

        public async Task AddIncident(IncidentDto incident)
        {
            if (incident == null || incident.Location == null)
            {
                throw new ArgumentException();
            }

            // We could use AutoMapper for a more complex application
            var newIncident = new Incident
            {
                Title = incident.Title,
                Description = incident.Description,
                Occurence = incident.Occurence,
                Location = new Location
                {
                    Latitude = incident.Location.Latitude,
                    Longitude = incident.Location.Longitude,
                }
            };

            _context.Incidents.Add(newIncident);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<IncidentDto>> Get()
        {
            // We could use AutoMapper for a more complex application
            Expression<Func<Incident, IncidentDto>> incidentMapping = (Incident i) =>
            new IncidentDto
            {
                Id = i.Id,
                Title = i.Title,
                Description = i.Description,
                Occurence = i.Occurence,
                Location = new LocationDto
                {
                    Latitude = i.Location.Latitude,
                    Longitude = i.Location.Longitude
                }
            };

            IEnumerable<IncidentDto> incidents = await _context.Incidents
                .AsNoTracking()
                .Include(i => i.Location)
                .Select(incidentMapping)
                .ToListAsync();
            return incidents;
        }
    }
}
