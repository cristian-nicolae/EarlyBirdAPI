﻿// <auto-generated />
using System;
using EarlyBird.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EarlyBird.DataAccess.Migrations
{
    [DbContext(typeof(EarlyBirdContext))]
    partial class EarlyBirdContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("EarlyBird.DataAccess.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EarlyBird.DataAccess.Entities.LocationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("EarlyBird.DataAccess.Entities.OfferCategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OfferId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OfferId");

                    b.ToTable("OfferCategories");
                });

            modelBuilder.Entity("EarlyBird.DataAccess.Entities.OfferEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("AccepterId")
                        .HasColumnType("TEXT");

                    b.Property<double>("Cost")
                        .HasMaxLength(100)
                        .HasColumnType("REAL");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notes")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Prerequisites")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PublisherId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccepterId");

                    b.HasIndex("LocationId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("EarlyBird.DataAccess.Entities.ReviewEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("EarlyBird.DataAccess.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EarlyBird.DataAccess.Entities.OfferCategoryEntity", b =>
                {
                    b.HasOne("EarlyBird.DataAccess.Entities.CategoryEntity", "Category")
                        .WithMany("Offers")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EarlyBird.DataAccess.Entities.OfferEntity", "Offer")
                        .WithMany("Categories")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Offer");
                });

            modelBuilder.Entity("EarlyBird.DataAccess.Entities.OfferEntity", b =>
                {
                    b.HasOne("EarlyBird.DataAccess.Entities.UserEntity", "Accepter")
                        .WithMany()
                        .HasForeignKey("AccepterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EarlyBird.DataAccess.Entities.LocationEntity", "Location")
                        .WithMany("Offers")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EarlyBird.DataAccess.Entities.UserEntity", "Publisher")
                        .WithMany("Offers")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accepter");

                    b.Navigation("Location");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("EarlyBird.DataAccess.Entities.ReviewEntity", b =>
                {
                    b.HasOne("EarlyBird.DataAccess.Entities.UserEntity", "Receiver")
                        .WithMany("ReviewsReceived")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EarlyBird.DataAccess.Entities.UserEntity", "Sender")
                        .WithMany("ReviewsSent")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("EarlyBird.DataAccess.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Offers");
                });

            modelBuilder.Entity("EarlyBird.DataAccess.Entities.LocationEntity", b =>
                {
                    b.Navigation("Offers");
                });

            modelBuilder.Entity("EarlyBird.DataAccess.Entities.OfferEntity", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("EarlyBird.DataAccess.Entities.UserEntity", b =>
                {
                    b.Navigation("Offers");

                    b.Navigation("ReviewsReceived");

                    b.Navigation("ReviewsSent");
                });
#pragma warning restore 612, 618
        }
    }
}
