using AutoMapper;
using fixit.DTO;
using fixit.Models;

namespace fixit.Profiles
{
    public class TechnicianProfile : Profile
    {
        public TechnicianProfile()
        {
            CreateMap<fixit.Models.Technician, TechnicianDto>()
            .ForMember(dest => dest.TechnicianId, opt => opt.MapFrom(src => src.TechnicianId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Experiance, opt => opt.MapFrom(src => src.Experiance))
            .ForMember(dest => dest.CompletedWork, opt => opt.MapFrom(src => src.CompletedWork))
            .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
            CreateMap<TechnicianDto, fixit.Models.Technician>();
        }
    }
}

