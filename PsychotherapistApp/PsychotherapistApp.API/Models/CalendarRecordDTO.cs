using PsychotherapistApp.Data.Models;
using System;

namespace PsychotherapistApp.API.Models
{
    public class CalendarRecordDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public FrequencyEnum Frequency { get; set; }
        public int RoomNumber { get; set; }
        public PsychotherapistDTO Psychotherapist { get; set; }
        public int PsychotherapistId { get; set; }
    }
}
