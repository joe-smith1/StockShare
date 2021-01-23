using AutoMapper;
using SPA.Models.Dtos;
using SPA.Models.Entities;

namespace SPA.Helpers
{
    /// <summary>
    /// Mapping profiles for auto mapper,
    /// stores all the configurations for which objects to map from and to
    /// automatically as well as their specific mapping properties if it
    /// cant be determined automatically. These mapping configurations
    /// can then be used latter through dependency injection as this profile
    /// is provided to the mapping service.
    /// </summary>
    public class AutoMapperOrganizationProfile : Profile
    {
        public AutoMapperOrganizationProfile()
        {
            // ApplicationUser Mappings.
            CreateMap<RegisterDto, ApplicationUser>();

            // Stock Mappings.
            CreateMap<StockCreationDto, Stock>();
            CreateMap<StockUpdateDto, Stock>();
            CreateMap<Stock, StockDto>();
        }
    }
}