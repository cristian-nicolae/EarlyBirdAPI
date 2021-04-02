using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.BusinessLogic.Utils
{
    public class AuthorizationSettings
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int TokenLifetimeInMinutes { get; set; }
    }
}
