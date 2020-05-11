using IncidentManagement.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;

namespace IncidentManagement.Services.Tests
{
    public static class ApplicationDbContextHelper
    {
        public static ApplicationDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Ensures new databases are created for every test
                .Options;
            return new ApplicationDbContext(options);
        }
    }
}
