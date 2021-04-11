using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class AddLocationDto
    {
        public string CityName { get; set; }

        public string StreetName { get; set; }

        public string StreetNumber { get; set; }

    }
}
