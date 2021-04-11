using AutoMapper;
using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.DataAccess.Entities;


namespace EarlyBird.BusinessLogic.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ViewUserDto, UserEntity>();
            CreateMap<UserEntity, ViewUserDto>();
            
            CreateMap<OfferEntity, UpdateOfferDto>();
            CreateMap<OfferEntity, ViewOfferDto>();
            CreateMap<OfferEntity, AddOfferDto>();

            CreateMap<AddOfferDto, ViewOfferDto>();
            CreateMap<AddOfferDto, OfferEntity>();
            CreateMap<AddOfferDto, UpdateOfferDto>();

            CreateMap<ViewOfferDto, OfferEntity>();
            CreateMap<ViewOfferDto, AddOfferDto>();
            CreateMap<ViewOfferDto, UpdateOfferDto>();
            
            CreateMap<UpdateOfferDto, OfferEntity>();
            

            CreateMap<ViewLocationDto, AddLocationDto>();
            CreateMap<ViewLocationDto, LocationEntity>();
            CreateMap<LocationEntity, AddLocationDto>();
            CreateMap<LocationEntity, ViewLocationDto>();
            CreateMap<AddLocationDto, ViewLocationDto>();
            CreateMap<AddLocationDto, LocationEntity>();
            

        }
    }
}