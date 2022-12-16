using PsychotherapistApp.Data.Models;
using System.Linq;

namespace PsychotherapistApp.Data.Interfaces
{
    public interface ICalendarRecordRepository
    {
        public IQueryable<CalendarRecord> GetAll();

        public CalendarRecord GetById(int id);

        public int Add(CalendarRecord calendarRecord);

        public CalendarRecord Update(CalendarRecord calendarRecord);

        public void DeleteById(int id);
    }
}
