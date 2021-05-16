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
        private readonly ICategoriesRepository categoriesRepository;
        private readonly IOfferCategoryRepository offerCategoryRepository;
        public OffersService(IOffersRepository offersRepository,
                             IMapper mapper,
                             ICategoriesService categoriesService,
                             ITokenService tokenService,
                             ICategoriesRepository categoriesRepository, 
                             IOfferCategoryRepository offerCategoryRepository)
        {
            this.offersRepository = offersRepository;
            this.categoriesService = categoriesService;
            this.mapper = mapper;
            this.tokenService = tokenService;
            this.categoriesRepository = categoriesRepository;
            this.offerCategoryRepository = offerCategoryRepository;
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
            if (!categoriesRepository.CategoriesExist(offerEntity.CategoryIds))
                throw new NotFoundException("One of the categories does not exist");

            var offer = offersRepository.Add(mapper.Map<OfferEntity>(offerEntity));

            if (offer == null)
                throw new FailedOperationException("The offer was not added");
            bool added = offerCategoryRepository.AddRange(offerEntity.CategoryIds, offer.Id);
            if (!added)
                throw new FailedOperationException("Failed to add the categories to the offer");

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

            if (updateOfferEntity.Location != null)
                offerEntity.Location = mapper.Map<LocationEntity>(updateOfferEntity.Location);

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

        }
        public class NotFoundException : Exception
        {
            public NotFoundException()
            {
            }

            public NotFoundException(string message) : base(message)
            {
            }

        }

        public class FailedOperationException : Exception
        {
            public FailedOperationException()
            {
            }

            public FailedOperationException(string message) : base(message)
            {
            }

        }
        #endregion

    }
}