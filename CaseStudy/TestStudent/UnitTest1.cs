using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniProject.Controllers;



namespace TestStudent
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
