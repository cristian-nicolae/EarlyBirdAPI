using EarlyBird.DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EarlyBird.DataAccess.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Username { get; set; }

        [Required]
        [MaxLength(200)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(200)]
        public string Lastname { get; set; }
        [Required]
        [MaxLength(200)]
        public string PasswordHash { get; set; }
        [Required]
        [MaxLength(200)]
        public string Salt { get; set; }
        [Required]
        public Roles Role { get; set; }

        public ICollection<OfferEntity> OffersPublished { get; set; }
        public ICollection<OfferEntity> OffersAccepted { get; set; }
        public ICollection<ReviewEntity> ReviewsReceived { get; set; }

        public ICollection<ReviewEntity> ReviewsSent { get; set; }
    }
}
