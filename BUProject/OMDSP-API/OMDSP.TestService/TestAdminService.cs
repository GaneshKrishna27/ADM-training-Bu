using NUnit.Framework;
using OMDSP.AdminService.Models;
using OMDSP.AdminService.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OMDSP.TestService
{
    [TestFixture]
    class TestAdminService
    {

        AdminRepository _repo;
        [SetUp]
        public void SetUp()
        {
            _repo = new AdminRepository(new AdminService.Models.OMDSPDBContext());
        }
        [Test]
        [Description("Test ViewMedicinelist")]
        public void TestMedicineList()
        {
            var result = _repo.medicineList();
            Assert.IsNotNull(result);
            
        }
        [Test]
        [Description("Test AddNgolist")]
        public void TestAddNgoList()
        {
            _repo.ngoRegistration(new AdminService.Models.NgoList()
            {
                NgoId = "4",
                NgoName = "sriram ngo",
                NgoDesc="Blind peopkle",
                NgoGmail="Blind@gmail.com",
                NgoCity = "eluru",
                NgoAddress = "rrpet",
                NgoMobile = "9876543210"

            });

        }
        [Test]
        [Description("Test ViewUserlist")]
        public void TestViewUserlistt()
        {
            var result = _repo.userList();
            Assert.IsNotNull(result);

        }
        [Test]
        [Description("Test DeleteNgo")]
        public void DeleteCartItem()
        {
            _repo.deleteNgo("3");
            var result = _repo.GetNgoId("3");
            Assert.Null(result);
        }
        [Test]
        [Description("Test UpdateNgo")]
        public void TestUpdateNgo()
        {
            NgoList ngolist = _repo.GetNgoId("4");
            ngolist.NgoMobile = "9876567890";
            _repo.updateNgo(ngolist);
            NgoList ngolist1 = _repo.GetNgoId("4");
            Assert.AreSame(ngolist, ngolist1);


        }
    }
}
