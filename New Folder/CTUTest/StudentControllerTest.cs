using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using CTUCampus.Controllers;
using CTUCampus.Models;

//

namespace CTUTest
{
    [TestClass]
    public class StudentControllerTest
    {
        [TestMethod]
        public void Test_Index_Return_View()
        {
            StudentController sc = new StudentController();
            var result = sc.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
