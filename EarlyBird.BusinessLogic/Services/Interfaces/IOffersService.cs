
using EarlyBird.BusinessLogic.DTOs;
using System;
using System.Collections.Generic;

namespace EarlyBird.BusinessLogic.Services.Interfaces
{
    public interface IOffersService
    {

        ViewOfferDto GetById(int id);

        IEnumerable<ViewOfferDto> GetAllByStatus(OfferStatus offerStatus);

        ViewOfferDto Add(AddOfferDto offerEntity);

        bool Delete(int id);

        bool Update(int id, UpdateOfferDto offerEntity);

        Guid GetPublisherId(int offerId);
    }
}
