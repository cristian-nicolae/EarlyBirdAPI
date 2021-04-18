using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EarlyBird.DataAccess.Utils;

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

        public OfferEntity GetById(int id)
        {
            return context.Offers.Include(x => x.Location).Include(x => x.Publisher).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<OfferEntity> GetAllOffers(OfferFilterAndSortDAO query)
        {
            var offerQuery = context.Offers
                                    .Include(x => x.Location)
                                    .Include(x => x.Categories)
                                    .ThenInclude(x => x.Category)
                                    .AsQueryable();

            if (!String.IsNullOrWhiteSpace(query.Text))
                offerQuery = offerQuery.Where(x => x.Title.Contains(query.Text) || x.Description.Contains(query.Text));

            if (query.TitleAscending.HasValue)
            {
                if (query.TitleAscending.Value) offerQuery = offerQuery.OrderBy(x => x.Title);
                else offerQuery = offerQuery.OrderByDescending(x => x.Title);
            }
            if (query.CostAscending.HasValue)
            {
                if (query.CostAscending.Value) offerQuery = offerQuery.OrderBy(x => x.Cost);
                else offerQuery = offerQuery.OrderByDescending(x => x.Cost);
            }
            if (query.MaxCost.HasValue)
                offerQuery = offerQuery.Where(x => x.Cost <= query.MaxCost);

            if (query.MinCost.HasValue)
                offerQuery = offerQuery.Where(x => x.Cost >= query.MinCost);

            if (query.CategoryIds.Any())
                offerQuery = offerQuery.Where(x => x.Categories
                .Any(x => query.CategoryIds.Contains(x.CategoryId)));

            if (query.Cities.Any())
                offerQuery = offerQuery.Where(x => query.Cities.Contains(x.Location.CityName));

            if (query.OfferStatus.HasValue)
                offerQuery = offerQuery.Where(x => x.Status == query.OfferStatus);

            if (query.IsPublisher.HasValue)
            {
                if (query.IsPublisher.Value) offerQuery = offerQuery.Where(x => x.PublisherId == query.UserId.Value);
                else offerQuery = offerQuery.Where(x => x.AccepterId == query.UserId.Value);
            }

            return offerQuery.ToList();
        }

        public bool Update(int id, OfferEntity offerEntity)
        {
            context.Update<OfferEntity>(offerEntity);
            return context.SaveChanges() > 0;
        }
    }
}
