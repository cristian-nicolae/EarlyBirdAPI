

namespace EarlyBird.BusinessLogic.Utils
{

        public enum Roles
        {
            Admin = 1,
            Worker,
            Publisher
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
