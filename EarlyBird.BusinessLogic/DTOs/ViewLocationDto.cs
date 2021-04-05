using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class ViewLocationDto
    {
        public int Id { get; set; }
        
        public string CityName { get; set; }

        public string StreetName { get; set; }

        public string StreetNumber { get; set; }

    }
}
