using PsychotherapistApp.Data.Models;
using System.Linq;

namespace PsychotherapistApp.Data.Interfaces
{
    public interface IPsychotherapistRepository
    {
        public IQueryable<Psychotherapist> GetAll();

        public Psychotherapist GetById(int id);

        public int Add(Psychotherapist psychotherapist);

        public Psychotherapist Update(Psychotherapist psychotherapist);

        public void DeleteById(int id);
    }
}
