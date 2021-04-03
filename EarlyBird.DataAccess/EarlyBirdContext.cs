using BCrypt.Net;
using EarlyBird.DataAccess.Entities;
using EarlyBird.DataAccess.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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

            modelBuilder.Entity<UserEntity>().HasData(SeedUsers());
        }

        #region private methods
        private IEnumerable<UserEntity> SeedUsers()
        {
            var users = new List<UserEntity>();
            var salt1 = BCrypt.Net.BCrypt.GenerateSalt();
            users.Add(new UserEntity
            {
                Id = Guid.Parse("07d94746-c113-4de6-a0bf-8c4789b51c67"),
                Username = "admin",
                Salt = salt1,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin" + salt1),
                Role = Roles.Admin
            });

            var salt2 = BCrypt.Net.BCrypt.GenerateSalt();
            users.Add(new UserEntity
            {
                Id = Guid.Parse("6ac15295-fffe-49a8-aaaf-cca3255e9bb0"),
                Username = "worker",
                Salt = salt2,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("worker" + salt2),
                Role = Roles.Worker
            });

            var salt3 = BCrypt.Net.BCrypt.GenerateSalt();
            users.Add(new UserEntity
            {
                Id = Guid.Parse("3a779cd5-acf9-44be-b1c9-342f5edc88cb"),
                Username = "publisher",
                Salt = salt3,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("publisher" + salt3),
                Role = Roles.Publisher
            });

            return users;
        }
        #endregion


    }
}
