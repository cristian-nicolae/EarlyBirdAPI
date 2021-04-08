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
        private readonly EarlyBirdContext context;

        public OffersRepository(EarlyBirdContext context)
        {
            this.context = context;
        }

        public OfferEntity Add(OfferEntity offerEntity)
        {
            context.Offers.Add(offerEntity);
            context.SaveChanges();
            return offerEntity;
        }

        public bool Delete(OfferEntity offerEntity)
        {
            context.Offers.Remove(offerEntity);
            return context.SaveChanges() > 0;
        }

        public IEnumerable<OfferEntity> GetAllByStatus(OfferStatus offerStatus)
        {
            return context.Offers.Where(x => x.Status == offerStatus).ToList();
        }

        public OfferEntity GetById(int id)
        {
            return context.Offers.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<OfferEntity> GetPublisherOffers(Guid publisherId)
        {
             return context.Offers.Where(x => x.PublisherId == publisherId).ToList();
        }

        public bool Update(int id, OfferEntity offerEntity)
        {
            context.Update<OfferEntity>(offerEntity);
            return context.SaveChanges() > 0;
        }
    }
}
