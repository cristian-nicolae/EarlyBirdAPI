using EarlyBird.BusinessLogic.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EarlyBird.DataAccess.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Salt { get; set; }
        [Required]
        public Roles Role { get; set; }

        public ICollection<OfferEntity> Offers { get; set; }

        public ICollection<ReviewEntity> ReviewsReceived { get; set; }

        public ICollection<ReviewEntity> ReviewsSent { get; set; }
    }
}
