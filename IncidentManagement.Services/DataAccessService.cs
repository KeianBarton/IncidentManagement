using IncidentManagement.DataAccess;
using IncidentManagement.Services.DataAccessQueries;

namespace IncidentManagement.Services
{
    public class DataAccessService : IDataAccessService
    {
        public IIncidentQueries IncidentQueries { get; }
        public ILocationQueries LocationQueries { get; }

        public DataAccessService(ApplicationDbContext context)
        {
            IncidentQueries = new IncidentQueries(context);
            LocationQueries = new LocationQueries(context);
        }
    }
}
