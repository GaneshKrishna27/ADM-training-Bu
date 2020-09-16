using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniProject.Controllers;
using MiniProject.Models;


namespace TestStudentDetails
{
    
    [TestClass]
    public class UnitTest1
    {
        
        //[TestMethod]
        //public void TestIndex()
        //{
        //    var obj = new StudentsController();
        //    string option = "stuBranch";
        //    string search = "CSE";
        //    var result = obj.Index(option,search) as ViewResult;

        //    // Now lets evrify whether the result contains our book entries or not
        //    var model = (List<StudentDBEntities>)result.ViewData.Model;

        //    Assert.IsNotNull(model);
        //    //CollectionAssert.Contains(model, 1);
        //    //CollectionAssert.Contains(model, 2);
        //    //CollectionAssert.Contains(model, 3);
        //}
        [TestMethod]
        public void TestDetails()
        {
            var obj = new StudentsController();
            var result = obj.Details(1) as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
