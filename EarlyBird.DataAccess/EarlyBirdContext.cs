using EarlyBird.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EarlyBird.DataAccess
{
    public class EarlyBirdContext : DbContext
    {
        public EarlyBirdContext(DbContextOptions<EarlyBirdContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<OfferEntity> Offers { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<LocationEntity> Locations { get; set; }
        public DbSet<OfferCategoryEntity> OfferCategories { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OfferEntity>()
                .HasOne<UserEntity>(o => o.Publisher)
                .WithMany(u => u.Offers)
                .HasForeignKey(o => o.PublisherId);


            modelBuilder.Entity<ReviewEntity>()
                 .HasOne<UserEntity>(r => r.Receiver)
                 .WithMany(u => u.ReviewsReceived)
                 .HasForeignKey(r => r.ReceiverId);

            modelBuilder.Entity<ReviewEntity>()
                 .HasOne<UserEntity>(r => r.Sender)
                 .WithMany(u => u.ReviewsSent)
                 .HasForeignKey(r => r.SenderId);


            modelBuilder.Entity<OfferCategoryEntity>()
                 .HasOne<CategoryEntity>(oc => oc.Category)
                 .WithMany(c => c.Offers)
                 .HasForeignKey(oc => oc.CategoryId);
            modelBuilder.Entity<OfferCategoryEntity>()
                 .HasOne<OfferEntity>(oc => oc.Offer)
                 .WithMany(o => o.Categories)
                 .HasForeignKey(oc => oc.OfferId);
        }

    }
}
