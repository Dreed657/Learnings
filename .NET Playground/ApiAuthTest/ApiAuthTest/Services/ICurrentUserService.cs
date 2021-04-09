using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAuthTest.Services
{
    public interface ICurrentUserService
    {
        string GetUserName();

        string GetId();
    }
}
