using Microsoft.EntityFrameworkCore;
using PsychotherapistApp.Data.Contexts;
using PsychotherapistApp.Data.Interfaces;
using PsychotherapistApp.Data.Models;
using System.Linq;

namespace PsychotherapistApp.Data.Repositories
{
    public class CalendarRecordRepository : ICalendarRecordRepository
    {
        private readonly AppDbContext _context;
        public CalendarRecordRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<CalendarRecord> GetAll()
        {
            return _context.CalendarRecords.Include(x => x.Psychotherapist);
        }

        public CalendarRecord GetById(int id)
        {
            return _context.CalendarRecords.Include(x => x.Psychotherapist).FirstOrDefault(x => x.Id == id);
        }

        public int Add(CalendarRecord calendarRecord)
        {
            _context.CalendarRecords.Add(calendarRecord);
            _context.SaveChanges();

            return calendarRecord.Id;
        }

        public CalendarRecord Update(CalendarRecord calendarRecord)
        {
            var modelToUpdate = GetById(calendarRecord.Id);

            modelToUpdate.Description = calendarRecord.Description;
            modelToUpdate.Frequency = calendarRecord.Frequency;
            modelToUpdate.StartTime = calendarRecord.StartTime;
            modelToUpdate.EndTime = calendarRecord.EndTime;
            modelToUpdate.RoomNumber = calendarRecord.RoomNumber;
            modelToUpdate.PsychotherapistId = calendarRecord.PsychotherapistId;

            _context.SaveChanges();

            return modelToUpdate;
        }

        public void DeleteById(int id)
        {
            var modelToDelete = GetById(id);

            _context.CalendarRecords.Remove(modelToDelete);

            _context.SaveChanges();
        }
    }
}
