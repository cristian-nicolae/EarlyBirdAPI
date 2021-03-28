using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.DataAccess.Repositories
{
    public class OffersRepository : IOffersRepository
    {
        public OfferEntity Add(OfferEntity offerEntity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OfferEntity> GetAllAvailableOffers()
        {
            throw new NotImplementedException();
        }

        public OfferEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OfferEntity> GetPublisherOffers(Guid publisherId)
        {
            throw new NotImplementedException();
        }

        public bool Update(OfferEntity offerEntity)
        {
            throw new NotImplementedException();
        }
    }
}
