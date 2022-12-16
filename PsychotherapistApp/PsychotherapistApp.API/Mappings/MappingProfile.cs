using AutoMapper;
using PsychotherapistApp.API.Models;
using PsychotherapistApp.Data.Models;

namespace PsychotherapistApp.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CalendarRecord, CalendarRecordDTO>().ReverseMap();
            CreateMap<Psychotherapist, PsychotherapistDTO>().ReverseMap();
        }
    }
}
