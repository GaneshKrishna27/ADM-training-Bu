using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OMDSP.UserService.Repositories;
using OMDSP.UserService.Models;


namespace OMDSP.TestService
{
    [TestFixture]
    public class TestUserService
    {
        UserRepository _repo;
        [SetUp]
        public void SetUp()
        {
            _repo = new UserRepository(new UserService.Models.OMDSPDBContext());

        }
        [Test]
        [Description("Test medicinelist")]
        public void TestaddMedicinelist()
        {
            //var result = _repo.donateMedicine("3");
            //Assert.IsNotNull(result);
            _repo.donateMedicine(new MedicineList()
            {
                MId = "3",
                MName = "Benadel",
                ExpDate = DateTime.Now,
                DonorName = "krishna",
                DonorCity = "eluru",
                DonorAddress = "rrpet",
                DonorMobile = "9876543210"

            });
        }
        [Test]
        [Description("Test ViewNgoList")]
        public void viewNgolist()
        {
            var result = _repo.searchNgo();
            Assert.IsNotNull(result);
        }

    }
}
