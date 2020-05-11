using System.Collections.Generic;

namespace IncidentManagement.DataAccess.Entities
{
    public class Location
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public virtual IEnumerable<Incident> Incidents { get; set; }
    }
}
