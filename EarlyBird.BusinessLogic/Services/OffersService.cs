using EarlyBird.BusinessLogic.DTOs;
using EarlyBird.BusinessLogic.Services.Interfaces;
using EarlyBird.BusinessLogic.Utils;
using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories;
using EarlyBird.DataAccess.Repositories.Interfaces;
using EarlyBird.DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using AutoMapper;
using Abp.Domain.Entities;

namespace EarlyBird.BusinessLogic.Services
{
    public class OffersService : IOffersService
    {
        private readonly IOffersRepository offersRepository;
        private readonly IMapper mapper;

        public OffersService(IOffersRepository offersRepository, IMapper mapper)
        {
            this.offersRepository = offersRepository;
            this.mapper = mapper;
        }

        public ViewOfferDto GetById(int id)
        {
            var offer = offersRepository.GetById(id);
            if (offer == null) return null;

            return mapper.Map<ViewOfferDto>(offer);
        }

        public IEnumerable<ViewOfferDto> GetAllByStatus(OfferStatus offerStatus)
        {
            var offers = offersRepository.GetAllByStatus(offerStatus);
            return offers.Select(offer => mapper.Map<ViewOfferDto>(offer)).ToList();
        }

        public ViewOfferDto Add(AddOfferDto offerEntity)
        {
            var offer = offersRepository.Add(mapper.Map<OfferEntity>(offerEntity));
            return mapper.Map<ViewOfferDto>(offer);
        }

        public bool Delete(int id)
        {
            var offer = offersRepository.GetById(id);
            if (offer == null) throw new EntityNotFoundException() ;

            return offersRepository.Delete(offer);
        }

        public bool Update(int id, UpdateOfferDto offerEntity)
        {
              var offer = mapper.Map<OfferEntity>(offerEntity);
              return offersRepository.Update(id, offer);
        }

        public Guid GetPublisherId(int offerId){
               var offer = GetById(offerId);
               return offer.PublisherId;
        }
        
    }
}