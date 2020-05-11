using IncidentManagement.DataAccess;
using Xunit;

namespace IncidentManagement.Services.Tests
{
    public class DataAccessServiceTests
    {
        [Fact]
        public void Constructor_ShouldSetUpQueries_IfCalled()
        {
            // Arrange
            ApplicationDbContext context = ApplicationDbContextHelper.GetContext();

            // Act
            var dataAccessService = new DataAccessService(context);

            // Assert
            Assert.NotNull(dataAccessService.IncidentQueries);
            Assert.NotNull(dataAccessService.LocationQueries);
        }
    }
}
