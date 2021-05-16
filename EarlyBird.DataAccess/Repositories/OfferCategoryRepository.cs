using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.DataAccess.Repositories
{
    public class OfferCategoryRepository : IOfferCategoryRepository
    {
        private readonly EarlyBirdContext context;
        public OfferCategoryRepository(EarlyBirdContext context)
        {
            this.context = context;
        }
        public bool AddRange(IEnumerable<int> categoryIds, int offerId)
        {
            var offerCategoryEntities = categoryIds.Select(x => new OfferCategoryEntity { CategoryId = x, OfferId = offerId });
            context.OfferCategories.AddRange(offerCategoryEntities);
            return context.SaveChanges() > 0;
        }
    }
}
