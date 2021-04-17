using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.BusinessLogic.Services.Interfaces;
using EarlyBird.BusinessLogic.Utils;
using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories;
using EarlyBird.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using AutoMapper;
using Abp.Domain.Entities;
using EarlyBird.DataAccess.Utils;
using System.Security.Claims;


namespace EarlyBird.BusinessLogic.Services
{
    public class OffersService : IOffersService
    {
        private readonly IOffersRepository offersRepository;
        private readonly ICategoriesService categoriesService;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;

        public OffersService(IOffersRepository offersRepository,
                             IMapper mapper,
                             ICategoriesService categoriesService,
                             ITokenService tokenService)
        {
            this.offersRepository = offersRepository;
            this.categoriesService = categoriesService;
            this.mapper = mapper;
            this.tokenService = tokenService;
        }

        public ViewOfferDto GetById(int id)
        {
            var offer = offersRepository.GetById(id);
            if (offer == null) throw new OfferNotFoundException("Offer could not be found");

            return mapper.Map<ViewOfferDto>(offer);
        }

        public IEnumerable<ViewOfferDto> GetAllOffers(OfferFilterAndSort offerFilter, ClaimsIdentity identity = null)
        {
            var offerDAO = mapper.Map<OfferFilterAndSortDAO>(offerFilter);
            offerDAO.UserId = null;
            offerDAO.IsPublisher = null;
            var filterByUser = offerFilter.FilterByCurrentUser;
            if (filterByUser.GetValueOrDefault())
            {
                offerDAO.UserId = tokenService.GetUserIdFromClaims(identity);
                offerDAO.IsPublisher = tokenService.GetRoleFromClaims(identity) == Roles.Publisher;
            }

            var offerEntities = offersRepository.GetAllOffers(offerDAO).ToList();
            var offers = offerEntities.Select(offer => mapper.Map<ViewOfferDto>(offer)).ToList();
            return offers;
        }

        public ViewOfferDto Add(AddOfferDto offerEntity)
        {
            var offer = offersRepository.Add(mapper.Map<OfferEntity>(offerEntity));
            return mapper.Map<ViewOfferDto>(offer);
        }

        public bool Delete(int id)
        {
            var offer = offersRepository.GetById(id);
            if (offer == null) throw new OfferNotFoundException("Offer could not be found");

            return offersRepository.Delete(offer);
        }

        public bool Update(int id, UpdateOfferDto updateOfferEntity)
        {
            var offerEntity = offersRepository.GetById(id);
            if (offerEntity == null)
                throw new OfferNotFoundException("Offer could not be found");

            offerEntity.Title = updateOfferEntity.Title ?? offerEntity.Title;
            offerEntity.Cost = updateOfferEntity.Cost == 0 ? offerEntity.Cost : updateOfferEntity.Cost;
            offerEntity.PublisherId = updateOfferEntity.PublisherId;
            offerEntity.Description = updateOfferEntity.Description ?? offerEntity.Description;
            offerEntity.Prerequisites = updateOfferEntity.Prerequisites ?? offerEntity.Prerequisites;
            offerEntity.Notes = updateOfferEntity.Notes ?? offerEntity.Notes;
            offerEntity.Status = updateOfferEntity.Status == 0 ? offerEntity.Status : updateOfferEntity.Status;
            offerEntity.Location = updateOfferEntity.Status == 0 ? offerEntity.Location : mapper.Map<LocationEntity>(updateOfferEntity.Location);
            return offersRepository.Update(id, offerEntity);
        }

        public Guid GetPublisherId(int offerId)
        {
            var offer = GetById(offerId);
            return offer.PublisherId;
        }


        #region Exceptions
        [Serializable]
        public class OfferNotFoundException : Exception
        {
            public OfferNotFoundException()
            {
            }

            public OfferNotFoundException(string message) : base(message)
            {
            }

            #endregion
        }
    }
}