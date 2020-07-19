using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMDSP.AccountService.Models;

namespace OMDSP.AccountService.Repositories
{
    public interface IAccountRepository
    {
        Registration userSignin(string userName, string userPwd);
        void userSignup(Registration registration);
    }
}
