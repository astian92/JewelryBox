using JewelryBox.Infrastructure.Data.Contracts;
using JewelryBox.Main.Data;
using JewelryBox.Main.Models.ViewModels;
using JewelryBox.Main.Tests.Models;
using JewelryBox.Main.Workers.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryBox.Main.Tests.Workers
{
    [TestClass]
    public class CareersWorkerTests
    {
        private readonly CareersWorker worker;
        private readonly Mock<IRepository<Career>> repMock;

        public CareersWorkerTests()
        {
            repMock = new Mock<IRepository<Career>>();
            SetupMocks();
            worker = new CareersWorker(repMock.Object);
        }

        private void SetupMocks()
        {
            
        }

        [TestMethod]
        public void GetCareerTestNullUsername()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => worker.GetCareer(null)
            );
        }

        [TestMethod]
        public void GetCareerTestNotExistingUsername()
        {
            //the rep.GetAll will return an empty sequence - will not result in an NullReferenceException
            Assert.ThrowsException<ArgumentException>(
                () => worker.GetCareer("tozo")
            );
        }

        [TestMethod]
        public void GetCareerTest()
        {
            string username = "tester";

            var populator = new Populator();
            var career = populator.GetCareer(username);
            repMock.Setup(m => m.GetAll())
                .Returns(new List<Career>()
                {
                    career
                }.AsQueryable());

            var actual = worker.GetCareer(username);

            Assert.IsNotNull(actual);
            Assertor.AreSame(career, actual);
        }

        [TestMethod]
        public void SendPersonalMessageTestNullModel()
        {
            Assert.ThrowsException<NullReferenceException>(
                () => worker.SavePersonalMessage(null)
            );
        }

        [TestMethod]
        public void SendPersonalMessageTest()
        {
            string username = "receiver";
            var populator = new Populator();
            var career = populator.GetCareer(username);
            repMock.Setup(m => m.GetAll())
                .Returns(new List<Career>()
                {
                    career
                }.AsQueryable());

            var message = new PersonalMessageVM()
            {
                username = username,
                Name = "sender",
                Email = "sender@abv.bg",
                Message = "very cool test"
            };

            worker.SavePersonalMessage(message);

            Assert.AreEqual(1, career.VisitorMessages.Count);

            var savedMessage = career.VisitorMessages.First();

            Assert.AreEqual(message.Name, savedMessage.SenderName);
            Assert.AreEqual(message.Email, savedMessage.SenderEmailAddress);
            Assert.AreEqual(message.Message, savedMessage.Message);
        }
    }
}
