using System;
using System.Collections.Generic;

namespace PsychotherapistApp.Data.Models
{
    public class CalendarRecord
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public FrequencyEnum Frequency { get; set; }
        public int RoomNumber { get; set; }
        public virtual Psychotherapist Psychotherapist { get; set; }
        public int PsychotherapistId { get; set; }
    }
}
