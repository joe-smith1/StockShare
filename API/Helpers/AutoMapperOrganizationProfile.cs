using API.Data.Dtos;
using API.Data.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperOrganizationProfile : Profile
    {
        // TODO Document class.
        public AutoMapperOrganizationProfile()
        {
            CreateMap<ApplicationUser, AuthenticatedUserDto>();
            CreateMap<RegisterDto, ApplicationUser>();
        }
    }
}