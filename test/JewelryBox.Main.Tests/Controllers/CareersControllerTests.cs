using JewelryBox.Main.Controllers;
using JewelryBox.Main.Models.ViewModels;
using JewelryBox.Main.Models.Wrappers;
using JewelryBox.Main.Workers.Contracts;
using JewelryBox.Main.Workers.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace JewelryBox.Main.Tests.Controllers
{
    [TestClass]
    public class CareersControllerTests
    {
        private readonly CareersController controller;
        private readonly Mock<ICareersWorker> workerMock;

        public CareersControllerTests()
        {
            workerMock = new Mock<ICareersWorker>();
            SetupMocks();
            controller = new CareersController(workerMock.Object);

            var urlMock = new Mock<UrlHelper>();
            urlMock.Setup(m => m.Action(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RouteValueDictionary>()))
                .Returns<string, string, RouteValueDictionary>((a, c, r) => c + "/" + a);

            controller.Url = urlMock.Object;
        }

        private void SetupMocks()
        {
            workerMock.Setup(m => m.GetCareer(It.IsAny<string>()))
                .Returns(new CareerW() { });
        }

        [TestMethod]
        public void PersonTest()
        {
            string person = "tester";
            var actual = controller.Person(person);

            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(ViewResult));

            var view = actual as ViewResult;
            var model = view.Model;

            Assert.IsNotNull(model);
            Assert.IsInstanceOfType(model, typeof(CareerW));
        }

        [TestMethod]
        public void PersonalMessageTest()
        {
            string username = "tester";
            var actual = controller.PersonalMessage(username);

            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(PartialViewResult));

            var view = actual as PartialViewResult;
            var model = view.Model;

            Assert.IsNotNull(model);
            Assert.IsInstanceOfType(model, typeof(PersonalMessageVM));

            var pvm = model as PersonalMessageVM;
            Assert.AreEqual(username, pvm.username);
        }

        [TestMethod]
        public void SendPersonalMessageTestWrongModel()
        {
            controller.ModelState.AddModelError("something went wrong", new Exception());

            var actual = controller.SendPersonalMessage(null);

            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(RedirectResult));

            var result = actual as RedirectResult;
            Assert.AreEqual("Home/Error", result.Url);
        }

        [TestMethod]
        public void SendPersonalMessageTest()
        {
            var message = new PersonalMessageVM()
            {
                username = "tester",
                Name = "Tester McTestovich",
                Email = "mail",
                Message = "Test me"
            };

            var actual = controller.SendPersonalMessage(message);

            workerMock.Verify(m => m.SavePersonalMessage(message), Times.Once);

            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(RedirectResult));

            var result = actual as RedirectResult;
            Assert.AreEqual("Careers/Person", result.Url);
        }


    }
}
