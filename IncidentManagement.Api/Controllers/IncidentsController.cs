using IncidentManagement.Services;
using IncidentManagement.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IncidentManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentsController : ControllerBase
    {
        private readonly IDataAccessService _dataAccessService;

        public IncidentsController(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }

        [HttpGet]
        public async Task<ActionResult> GetIncidents()
        {
            
            IEnumerable<IncidentDto> incidents = await _dataAccessService
                .IncidentQueries
                .Get();
            return Ok(incidents);
        }

        [HttpPost]
        public async Task<ActionResult> AddIncident(IncidentDto incident)
        {
            await _dataAccessService
                .IncidentQueries
                .AddIncident(incident);
            return NoContent();
        }
    }
}
