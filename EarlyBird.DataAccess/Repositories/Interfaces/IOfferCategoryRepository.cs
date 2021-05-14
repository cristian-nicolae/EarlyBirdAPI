using System.Collections.Generic;

namespace EarlyBird.DataAccess.Repositories.Interfaces
{
    public interface IOfferCategoryRepository
    {
        bool AddRange(IEnumerable<int> categoryIds, int offerId);
    }
}
