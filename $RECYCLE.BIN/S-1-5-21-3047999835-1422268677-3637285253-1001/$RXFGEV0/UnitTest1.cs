using System;
using System.Web.Mvc;
using Forms.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var obj = new UserController();
            var result = obj.userSignin() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
