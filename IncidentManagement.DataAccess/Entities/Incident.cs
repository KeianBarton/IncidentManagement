using System;

namespace IncidentManagement.DataAccess.Entities
{
    public class Incident
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Occurence { get; set; }

        public virtual Location Location { get; set; }
    }
}
