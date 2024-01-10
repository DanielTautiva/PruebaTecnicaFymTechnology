using AutoMapper;
using PruebaTecnicaFymTechnology.Models;
using PruebaTecnicaFymTechnology.Models.Dtos;

namespace PruebaTecnicaFymTechnology.Mappers
{
    public class Mappers : Profile
    {

        public Mappers()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }


    }
}
