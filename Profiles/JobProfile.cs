using AutoMapper;
using fixit.DTO;
using fixit.Models;

namespace fixit.Profiles
{
    public class JobProfile : Profile{
        public JobProfile(){
            CreateMap<Job, JobDto>();
            CreateMap<Job,JobCreateDto>();
        }
        
    }
}