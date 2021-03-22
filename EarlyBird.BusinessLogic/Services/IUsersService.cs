using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.BusinessLogic.Services
{
    public interface IUsersService
    {
        string Authenticate(string username, string password);

    }
}
