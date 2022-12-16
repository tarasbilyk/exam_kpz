using Microsoft.EntityFrameworkCore;
using PsychotherapistApp.Data.Models;
using System;
using System.Collections.Generic;

namespace PsychotherapistApp.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CalendarRecord> CalendarRecords { get; set; }
        public DbSet<Psychotherapist> Psychotherapists { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalendarRecord>().HasOne(x => x.Psychotherapist).WithMany(x => x.CalendarRecords).HasForeignKey(x => x.PsychotherapistId);

            var psychotherapists = new List<Psychotherapist>()
            {
                new Psychotherapist { Id = 1, Name = "Bob", Surname = "Green", Email = "bob.green@gmail.com" },
                new Psychotherapist { Id = 2, Name = "John", Surname = " Smith", Email = "john.smith@gmail.com"}
            };

            var calendarRecords = new List<CalendarRecord>()
            {
                new CalendarRecord { Id = 1, Description = "Description1", RoomNumber = 1, Frequency = FrequencyEnum.Weekly, StartTime = new TimeSpan(2, 0, 0), EndTime = new TimeSpan(2, 30, 0), PsychotherapistId = 1 },
                new CalendarRecord { Id = 2, Description = "Description2", RoomNumber = 1, Frequency = FrequencyEnum.Once, StartTime = new TimeSpan(1, 0, 0), EndTime = new TimeSpan(2, 0, 0), PsychotherapistId = 2 },

            };

            modelBuilder.Entity<Psychotherapist>().HasData(psychotherapists);
            modelBuilder.Entity<CalendarRecord>().HasData(calendarRecords);

            base.OnModelCreating(modelBuilder);
        }
    }
}
