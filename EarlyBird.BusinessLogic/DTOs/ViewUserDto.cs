using EarlyBird.DataAccess.Utils;
using System;

namespace EarlyBird.BusinessLogic.DTOs
{
    public class ViewUserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public double AvgRating { get; set; }
        public Roles Role { get; set; }
    }
}
