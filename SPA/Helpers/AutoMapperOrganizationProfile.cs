using System;
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
            CreateMap<ApplicationUser, AccountUpdateDto>();


            // TODO research better way of doing this its very repetitive.
            CreateMap<AccountUpdateDto, ApplicationUser>()
                .ForMember(dest => dest.UserName, options => options.MapFrom((src, dest) => string.IsNullOrEmpty(src.UserName) ? dest.UserName : src.UserName))
                .ForMember(dest => dest.PhoneNumber, options => options.MapFrom((src, dest) => string.IsNullOrEmpty(src.PhoneNumber) ? dest.PhoneNumber : src.PhoneNumber))
                .ForMember(dest => dest.FavoriteMarket, options => options.MapFrom((src, dest) => string.IsNullOrEmpty(src.FavoriteMarket) ? dest.FavoriteMarket : src.FavoriteMarket))
                .ForMember(dest => dest.InvestmentOrientation, options => options.MapFrom((src, dest) => string.IsNullOrEmpty(src.InvestmentOrientation) ? dest.InvestmentOrientation : src.InvestmentOrientation))
                .ForMember(dest => dest.ProfileDescription, options => options.MapFrom((src, dest) => string.IsNullOrEmpty(src.ProfileDescription) ? dest.ProfileDescription : src.ProfileDescription))
                .ForMember(dest => dest.PrivateAccount, options => options.MapFrom((src, dest) => src.PrivateAccount ?? dest.PrivateAccount));


            // Stock Mappings.

            // Mapping the PurchaseDate of our stock entity to UTC Now if the dtos date is null.
            CreateMap<StockCreationDto, Stock>()
                .ForMember(dest => dest.PurchaseDate, options => options.MapFrom(src => src.PurchaseDate ?? DateTime.UtcNow));

            // Providing mapping configuration for each member of the DTO as we do not want to overwrite the destinations existing
            // properties if no change is provided in the dto e.g empty or null.
            CreateMap<StockUpdateDto, Stock>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Ticker,
                    options => options.MapFrom((src, dest) => string.IsNullOrEmpty(src.Ticker) ? dest.Ticker : src.Ticker))
                .ForMember(dest => dest.Shares,
                    options => options.MapFrom((src, dest) => src.Shares ?? dest.Shares))
                .ForMember(dest => dest.PurchaseDate,
                    options =>
                        options.MapFrom((src, dest) => src.PurchaseDate ?? dest.PurchaseDate))
                .ForMember(dest => dest.ValueAtPurchase,
                    options =>
                        options.MapFrom((src, dest) => src.ValueAtPurchase ?? dest.ValueAtPurchase))
                .ForMember(dest => dest.ExchangeMarket,
                    options =>
                        options.MapFrom((src, dest) =>
                            string.IsNullOrEmpty(src.ExchangeMarket) ? dest.ExchangeMarket : src.ExchangeMarket));


            CreateMap<Stock, StockDto>();
        }
    }
}