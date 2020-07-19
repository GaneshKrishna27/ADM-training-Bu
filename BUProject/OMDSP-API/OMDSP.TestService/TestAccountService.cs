using NUnit.Framework;
using OMDSP.AccountService.Repositories;
using OMDSP.AccountService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMDSP.TestService
{
    [TestFixture]
    class TestAccountService
    {
        AccountRepository _repo;
        [SetUp]
        public void SetUp()
        {
            _repo = new AccountRepository(new AccountService.Models.OMDSPDBContext());
        }
        [Test]
        [Description("Test UserSignin")]
        public void TestUserSignin()
        {
            _repo.userSignup(new Registration
            {
                UserId = "3",
                UserName = "krishna",
                UserPwd = "krishna",
                Email = "krishna@gmail.com",
                Mobile = "9876543210"
            });
            var result = _repo.userSignin("krishna", "krishna");
            Assert.NotNull(result);
        }
    }
    
}
