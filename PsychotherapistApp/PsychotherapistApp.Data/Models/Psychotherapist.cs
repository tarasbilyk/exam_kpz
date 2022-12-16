using System.Collections.Generic;

namespace PsychotherapistApp.Data.Models
{
    public class Psychotherapist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public virtual ICollection<CalendarRecord> CalendarRecords { get; set; }
    }
}
