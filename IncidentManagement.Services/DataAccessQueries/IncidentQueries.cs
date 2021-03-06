﻿using IncidentManagement.DataAccess;
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

        public async Task Add(IncidentDto incident)
        {
            if
            (
                incident == null ||
                incident.Location == null ||
                incident.Occurrence == default ||
                incident.Occurrence > DateTime.Now
            )
            {
                throw new ArgumentException();
            }

            Location dbLocation = _context.Locations
                .SingleOrDefault
                (
                    l =>
                    l.Latitude == incident.Location.Latitude &&
                    l.Longitude == incident.Location.Longitude
                );

            // We could use AutoMapper for a more complex application
            var newIncident = new Incident
            {
                Title = incident.Title,
                Description = incident.Description,
                Occurrence = incident.Occurrence,
                Location = dbLocation ?? new Location
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
                Occurrence = i.Occurrence,
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
