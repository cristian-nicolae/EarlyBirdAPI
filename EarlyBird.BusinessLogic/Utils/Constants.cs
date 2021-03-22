using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.BusinessLogic.Utils
{
    public static class Constants
    {
        public static class Roles
        {
            public const string Admin = "Admin";
            public const string Worker = "Worker";
            public const string Publisher = "Publisher";
        }

        public static class Claims
        {
            public const string Admin = "Admin";
            public const string Worker = "Worker";
            public const string Publisher = "Publisher";
            public const string All = "All";
        }
        public static class Policies
        {
            public const string Admin = "Admin";
            public const string Worker = "Worker";
            public const string Publisher = "Publisher";
            public const string All = "All";
        }
    }
}
