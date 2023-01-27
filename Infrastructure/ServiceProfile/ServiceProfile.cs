using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.ServiceProfile
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Register, RegisterDto>().ReverseMap();
        }
    }
}