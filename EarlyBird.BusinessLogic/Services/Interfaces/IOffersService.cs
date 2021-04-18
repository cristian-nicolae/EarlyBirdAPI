

using EarlyBird.BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace EarlyBird.BusinessLogic.Services.Interfaces
{
    public interface IOffersService
    {

        ViewOfferDto GetById(int id);

        IEnumerable<ViewOfferDto> GetAllOffers(OfferFilterAndSort offerFilterQuery, ClaimsIdentity identity = null);

        ViewOfferDto Add(AddOfferDto offerEntity);

        bool Delete(int id);

        bool Update(int id, UpdateOfferDto offerEntity);

        Guid GetPublisherId(int offerId);
    }
}
