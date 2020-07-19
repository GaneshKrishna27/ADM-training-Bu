using OMDSP.AccountService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMDSP.AccountService.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly OMDSPDBContext _context;
        public AccountRepository(OMDSPDBContext context)
        {
            _context = context;
        }
        public Registration userSignin(string userName, string userPwd)
        {
            Registration r = _context.Registration.SingleOrDefault(e => e.UserName == userName && e.UserPwd == userPwd);
            if (r != null)
            {
                return r;
            }
            else
                return null; 
        }

        public void userSignup(Registration registration)
        {
            _context.Add(registration);
            _context.SaveChanges();
        }

    }
}
