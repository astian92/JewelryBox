using JewelryBox.Main.Controllers;
using JewelryBox.Main.Models.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JewelryBox.Main.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        private readonly HomeController controller;

        public HomeControllerTests()
        {
            controller = new HomeController();
        }

        [TestMethod]
        public void IndexTest()
        {
            var actual = controller.Index();

            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
        }

        [TestMethod]
        public void ErrorTestIncorrectParameters()
        {
            int errorCode = -9;
            var actual = controller.Error(errorCode, null);

            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(ViewResult));

            var view = actual as ViewResult;
            var model = view.Model;

            Assert.IsNotNull(model);
            Assert.IsInstanceOfType(model, typeof(ErrorVM));

            var errorVM = model as ErrorVM;
            Assert.AreEqual(errorVM.Code, errorCode);
            Assert.AreEqual(errorVM.Message, null);
        }

        [TestMethod]
        public void ErrorTest()
        {
            int errorCode = 500;
            string message = "test error message";
            var actual = controller.Error(errorCode, message);

            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(ViewResult));

            var view = actual as ViewResult;
            var model = view.Model;

            Assert.IsNotNull(model);
            Assert.IsInstanceOfType(model, typeof(ErrorVM));

            var errorVM = model as ErrorVM;
            Assert.AreEqual(errorVM.Code, errorCode);
            Assert.AreEqual(errorVM.Message, message);
        }
    }
}
