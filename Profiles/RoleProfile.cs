namespace fixit.Profiles
{
    public class RoleProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<fixit.Models.Role, RoleDto>()
            .ForMember(dest => des., opt => opt.MapFrom(src => src.ServiceId))
            .ForMember(dest => dest.AdvancedPrice, opt => opt.MapFrom(src => src.AdvancedPrice));
           CreateMap<RoleDto, fixit.Models.Role>();

    
    
    
 }

    }
}