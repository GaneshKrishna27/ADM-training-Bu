using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniProject.Controllers;
using System.Web.Mvc;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var obj = new StudentsController();
            var result = obj.Details(1) as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
