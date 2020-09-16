using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using 

namespace TestStudent
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIndex()
        {
            var s = new StudentsController();
            ActionResult result = controller.Index() as ViewResult;

            // Now lets evrify whether the result contains our book entries or not
            var model = (List<Book>)result.ViewData.Model;

            CollectionAssert.Contains(model, book1);
            CollectionAssert.Contains(model, book2);
            CollectionAssert.Contains(model, book3);
            CollectionAssert.Contains(model, book4);
        }
    }
}
