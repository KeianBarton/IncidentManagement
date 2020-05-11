using IncidentManagement.DataAccess;
using IncidentManagement.DataAccess.Entities;
using IncidentManagement.Services.DataAccessQueries;
using IncidentManagement.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IncidentManagement.Services.Tests.DataAccessQueries
{
    public class IncidentQueriesTests
    {
        public static IEnumerable<object[]> InvalidIncidentData =>
            new List<object[]>
            {
                new object[] { null },
                new object[]
                {
                    new IncidentDto
                    {
                        Location = null
                    }
                },
                new object[]
                {
                    new IncidentDto
                    {
                        Occurence = default,
                        Location = new LocationDto()
                    }
                },
                new object[]
                {
                    new IncidentDto
                    {
                        Occurence = DateTime.Today.AddDays(1),
                        Location = new LocationDto()
                    }
                }
            };

        [Theory]
        [MemberData(nameof(InvalidIncidentData))]
        public async Task Add_ShouldThrowException_IfIncidentInvalid(IncidentDto incident)
        {
            // Arrange
            ApplicationDbContext context = ApplicationDbContextHelper.GetContext();
            var incidentQueries = new IncidentQueries(context);

            // Act / Assert
            await Assert.ThrowsAsync<ArgumentException>(() => incidentQueries.Add(incident));
        }

        [Fact]
        public async Task Add_ShouldAddIncident_IfIncidentValid()
        {
            // Arrange
            ApplicationDbContext context = ApplicationDbContextHelper.GetContext();
            var incidentQueries = new IncidentQueries(context);
            var incidentDto = new IncidentDto
            {
                Description = "Example Description",
                Title = "Example Title",
                Occurence = new DateTime(2000, 12, 25),
                Location = new LocationDto
                {
                    Latitude = 1,
                    Longitude = 2
                },
            };

            // Act
            await incidentQueries.Add(incidentDto);

            // Assert
            Incident incident = Assert.Single(context.Incidents);
            Assert.Equal("Example Description", incident.Description);
            Assert.Equal("Example Title", incident.Title);
            Assert.Equal(new DateTime(2000, 12, 25), incident.Occurence);
            Assert.Single(context.Locations);
            Assert.NotNull(incident.Location);
            Assert.Equal(1, incident.Location.Latitude);
            Assert.Equal(2, incident.Location.Longitude);
        }

        [Fact]
        public async Task Add_ShouldAddIncident_IfIncidentValidAndLocationAlreadyExists()
        {
            // Arrange
            ApplicationDbContext context = ApplicationDbContextHelper.GetContext();
            var location = new Location
            {
                Latitude = 1,
                Longitude = 2
            };
            context.Add(location);
            context.SaveChanges();
            var incidentQueries = new IncidentQueries(context);
            var incidentDto = new IncidentDto
            {
                Description = "Example Description",
                Title = "Example Title",
                Occurence = new DateTime(2000, 12, 25),
                Location = new LocationDto
                {
                    Latitude = 1,
                    Longitude = 2
                },
            };

            // Act
            await incidentQueries.Add(incidentDto);

            // Assert
            Assert.Single(context.Locations);
            Incident incident = Assert.Single(context.Incidents);
            Assert.Equal("Example Description", incident.Description);
            Assert.Equal("Example Title", incident.Title);
            Assert.Equal(new DateTime(2000, 12, 25), incident.Occurence);
            Assert.Single(context.Locations);
            Assert.NotNull(incident.Location);
            Assert.Equal(1, incident.Location.Latitude);
            Assert.Equal(2, incident.Location.Longitude);
        }

        [Fact]
        public async Task Get_ShouldReturnIncidents_IfValidCall()
        {
            // Arrange
            ApplicationDbContext context = ApplicationDbContextHelper.GetContext();
            var incidentQueries = new IncidentQueries(context);
            var location1 = new Location
            {
                Latitude = 1,
                Longitude = 2
            };
            var location2 = new Location
            {
                Latitude = 3,
                Longitude = 4
            };
            context.AddRange(new List<Location> { location1, location2 });
            context.SaveChanges();
            var incident1 = new Incident
            {
                Description = "Example Description 1",
                Title = "Example Title 1",
                Occurence = new DateTime(2000, 12, 25),
                Location = location1
            };
            var incident2 = new Incident
            {
                Description = "Example Description 2",
                Title = "Example Title 2",
                Occurence = new DateTime(2000, 12, 25),
                Location = location1
            };
            var incident3 = new Incident
            {
                Description = "Example Description 3",
                Title = "Example Title 3",
                Occurence = new DateTime(2000, 12, 25),
                Location = location2
            };
            context.AddRange(new List<Incident> { incident1, incident2, incident3 });
            await context.SaveChangesAsync();

            // Act
            var actualIncidents = await incidentQueries.Get();

            // Assert
            Assert.Equal(3, actualIncidents.Count());
            IncidentDto actualIncident1 = Assert.Single(actualIncidents.Where(i => i.Id == incident1.Id));
            Assert.Equal(incident1.Description, actualIncident1.Description);
            Assert.Equal(incident1.Title, actualIncident1.Title);
            Assert.Equal(incident1.Occurence, actualIncident1.Occurence);
            Assert.NotNull(incident1.Location);
            Assert.Equal(location1.Latitude, actualIncident1.Location.Latitude);
            Assert.Equal(location1.Longitude, actualIncident1.Location.Longitude);
            IncidentDto actualIncident2 = Assert.Single(actualIncidents.Where(i => i.Id == incident2.Id));
            Assert.Equal(incident2.Description, actualIncident2.Description);
            Assert.Equal(incident2.Title, actualIncident2.Title);
            Assert.Equal(incident2.Occurence, actualIncident2.Occurence);
            Assert.NotNull(incident2.Location);
            Assert.Equal(location1.Latitude, actualIncident2.Location.Latitude);
            Assert.Equal(location1.Longitude, actualIncident2.Location.Longitude);
            IncidentDto actualIncident3 = Assert.Single(actualIncidents.Where(i => i.Id == incident3.Id));
            Assert.Equal(incident3.Description, actualIncident3.Description);
            Assert.Equal(incident3.Title, actualIncident3.Title);
            Assert.Equal(incident3.Occurence, actualIncident3.Occurence);
            Assert.NotNull(incident3.Location);
            Assert.Equal(location2.Latitude, actualIncident3.Location.Latitude);
            Assert.Equal(location2.Longitude, actualIncident3.Location.Longitude);
        }
    }
}
