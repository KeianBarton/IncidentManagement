using IncidentManagement.Services.DataAccessQueries;

namespace IncidentManagement.Services
{
    public interface IDataAccessService
    {
        IIncidentQueries IncidentQueries { get; }
        ILocationQueries LocationQueries { get; }
    }
}
