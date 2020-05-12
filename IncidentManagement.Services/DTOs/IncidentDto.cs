using System;

namespace IncidentManagement.Services.DTOs
{
    public class IncidentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Occurrence { get; set; }

        public LocationDto Location { get; set; }
    }
}
