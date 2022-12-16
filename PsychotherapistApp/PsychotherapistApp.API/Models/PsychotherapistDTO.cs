using System.Collections.Generic;

namespace PsychotherapistApp.API.Models
{
    public class PsychotherapistDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public List<CalendarRecordDTO> CalendarRecords { get; set; }
    }
}
