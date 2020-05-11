using IncidentManagement.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IncidentManagement.Services.DataAccessQueries
{
    public interface IIncidentQueries
    {
        Task<IEnumerable<IncidentDto>> Get();
        Task AddIncident(IncidentDto incident);
    }
}
