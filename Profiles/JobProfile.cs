using AutoMapper;
using fixit.DTO;
using fixit.Models;

namespace fixit.Profiles
{
    public class JobProfile : Profile{
        public JobProfile(){
           CreateMap<fixit.Models.Job, JobDto>()
            .ForMember(dest => dest.JobId, opt => opt.MapFrom(src => src.JobId ))
            .ForMember(dest => dest.JobName , opt => opt.MapFrom(src => src.JobName ))
            .ForMember(dest => dest.Description , opt => opt.MapFrom(src => src.Description ))
            .ForMember(dest => dest.UserId , opt => opt.MapFrom(src => src.UserId ))
            .ForMember(dest => dest.Location , opt => opt.MapFrom(src => src.Location ))
            .ForMember(dest => dest.TechnicianId  , opt => opt.MapFrom(src => src.TechnicianId ))
            .ForMember(dest => dest.AccepteStatus  , opt => opt.MapFrom(src => src.AccepteStatus ))
            .ForMember(dest => dest.DoneStatus   , opt => opt.MapFrom(src => src.AccepteStatus ))
            .ForMember(dest => dest.User   , opt => opt.MapFrom(src => src.User ))
            .ForMember(dest => dest.Technician  , opt => opt.MapFrom(src => src.Technician));
           CreateMap<JobDto, fixit.Models.Job>();

        }
        
    }
}