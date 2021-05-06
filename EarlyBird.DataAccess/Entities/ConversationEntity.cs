using System;
using System.ComponentModel.DataAnnotations;

namespace EarlyBird.DataAccess.Entities
{
    public class ConversationEntity
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public bool NewMessage { get; set; }

        [Required]
        public UserEntity First { get; set; }

        [Required]
        public UserEntity Second { get; set; }

        [Required]
        public Guid FirstId { get; set; }

        [Required]
        public Guid SecondId { get; set; }
    }
}
