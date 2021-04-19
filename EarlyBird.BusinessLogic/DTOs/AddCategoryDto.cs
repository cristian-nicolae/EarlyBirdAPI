using EarlyBird.DataAccess.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class AddCategoryDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
