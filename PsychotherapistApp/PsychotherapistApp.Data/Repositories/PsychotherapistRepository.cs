using Microsoft.EntityFrameworkCore;
using PsychotherapistApp.Data.Contexts;
using PsychotherapistApp.Data.Interfaces;
using PsychotherapistApp.Data.Models;
using System.Linq;

namespace PsychotherapistApp.Data.Repositories
{
    public class PsychotherapistRepository : IPsychotherapistRepository
    {
        private readonly AppDbContext _context;
        public PsychotherapistRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Psychotherapist> GetAll()
        {
            return _context.Psychotherapists.Include(x => x.CalendarRecords);
        }

        public Psychotherapist GetById(int id)
        {
            return _context.Psychotherapists.Include(x => x.CalendarRecords).FirstOrDefault(x => x.Id == id);
        }

        public int Add(Psychotherapist psychotherapist)
        {
            _context.Psychotherapists.Add(psychotherapist);
            _context.SaveChanges();

            return psychotherapist.Id;
        }

        public Psychotherapist Update(Psychotherapist psychotherapist)
        {
            var modelToUpdate = GetById(psychotherapist.Id);

            modelToUpdate.Name = psychotherapist.Name;
            modelToUpdate.Surname = psychotherapist.Surname;
            modelToUpdate.Email = psychotherapist.Email;

            _context.SaveChanges();

            return modelToUpdate;
        }

        public void DeleteById(int id)
        {
            var modelToDelete = GetById(id);

            _context.Psychotherapists.Remove(modelToDelete);

            _context.SaveChanges();
        }
    }
}
