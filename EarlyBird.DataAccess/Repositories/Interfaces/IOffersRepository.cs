
using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Utils;
using System;
using System.Collections.Generic;

namespace EarlyBird.DataAccess.Repositories.Interfaces
{
    public interface IOffersRepository
    {
        OfferEntity GetById(int id);
        IEnumerable<OfferEntity> GetAllOffers(OfferFilterAndSortDAO query);
        OfferEntity Add(OfferEntity offerEntity);
        bool Delete(OfferEntity offerEntity);
        bool Update(int id, OfferEntity offerEntity);
    }
}
