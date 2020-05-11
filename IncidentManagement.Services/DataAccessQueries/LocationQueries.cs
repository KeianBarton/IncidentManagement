using IncidentManagement.DataAccess;

namespace IncidentManagement.Services.DataAccessQueries
{
    public class LocationQueries : ILocationQueries
    {
        private readonly ApplicationDbContext _context;

        public LocationQueries(ApplicationDbContext context) => _context = context;
    }
}
