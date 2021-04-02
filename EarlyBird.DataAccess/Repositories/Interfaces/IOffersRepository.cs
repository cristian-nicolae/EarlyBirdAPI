
using EarlyBird.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace EarlyBird.DataAccess.Repositories.Interfaces
{
    public interface IOffersRepository
    {
        OfferEntity GetById(int id);
        IEnumerable<OfferEntity> GetAllAvailableOffers();
        IEnumerable<OfferEntity> GetPublisherOffers(Guid publisherId);
        OfferEntity Add(OfferEntity offerEntity);
        bool Delete(OfferEntity offerEntity);
        bool Update(int id, OfferEntity offerEntity);
    }
}
