using IncidentManagement.Api.Controllers;
using IncidentManagement.Services;
using IncidentManagement.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IncidentManagement.Api.Tests.Controllers
{
    public class IncidentsControllerTests
    {
        [Fact]
        public async Task GetIncidents_ShouldReturnIncidents_IfCallValid()
        {
            // Arrange
            var incidents = new List<IncidentDto>
            {
                new IncidentDto
                {
                    Id = 1,
                    Description = "Example Description",
                    Title = "Example Title",
                    Occurrence = new DateTime(2000, 12, 25),
                    Location = new LocationDto
                    {
                        Latitude = 1,
                        Longitude = 2
                    },
                }
            };
            var mockDataAccessService = new Mock<IDataAccessService>(MockBehavior.Strict);
            mockDataAccessService
                .Setup(das => das.IncidentQueries.Get())
                .ReturnsAsync(incidents);
            var incidentsController = new IncidentsController(mockDataAccessService.Object);

            // Act
            var result = await incidentsController.GetIncidents();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(incidents, okObjectResult.Value);
        }

        [Fact]
        public async Task AddIncident_ShouldReturnNoContent_IfCallValid()
        {
            // Arrange
            var incident = new IncidentDto
            {
                Description = "Example Description",
                Title = "Example Title",
                Occurrence = new DateTime(2000, 12, 25),
                Location = new LocationDto
                {
                    Latitude = 1,
                    Longitude = 2
                },
            };
            var mockDataAccessService = new Mock<IDataAccessService>(MockBehavior.Strict);
            mockDataAccessService
                .Setup(das => das.IncidentQueries.Add(incident))
                .Returns(Task.CompletedTask);
            var incidentsController = new IncidentsController(mockDataAccessService.Object);

            // Act
            var result = await incidentsController.AddIncident(incident);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
