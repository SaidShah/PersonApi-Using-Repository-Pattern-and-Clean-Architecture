using AutoMapper;
using PersonApi.Dtos;
using PersonApi.Models;

namespace PersonApi.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();
        }
    }
}