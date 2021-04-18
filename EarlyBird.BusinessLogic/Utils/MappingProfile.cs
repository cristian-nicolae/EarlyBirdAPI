using AutoMapper;
using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories.Interfaces;
using EarlyBird.DataAccess.Utils;

namespace EarlyBird.BusinessLogic.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile(IUsersRepository usersRepository)
        {
            CreateMap<ViewUserDto, UserEntity>();
            CreateMap<UserEntity, ViewUserDto>()
                .ForMember(
                dest=> dest.AvgRating,
                opt=> opt.MapFrom(src=> usersRepository.GetAverageRating(src.Id)));

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

            CreateMap<OfferFilterAndSort, OfferFilterAndSortDAO>();

            CreateMap<ViewCategoryDto, CategoryEntity>();
            CreateMap<CategoryEntity, ViewCategoryDto>();

            CreateMap<OfferCategoryEntity, ViewOfferCategoryDto>();
            CreateMap<ViewOfferCategoryDto, OfferCategoryEntity>();
        }
    }
}