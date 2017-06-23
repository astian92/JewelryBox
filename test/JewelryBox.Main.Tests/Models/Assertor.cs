using JewelryBox.Main.Data;
using JewelryBox.Main.Models.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryBox.Main.Tests.Models
{
    public class Assertor
    {
        public static void AreSame(Career career, CareerW careerW)
        {
            Assert.AreEqual(career.Id, careerW.Id);
            Assert.AreEqual(career.Firstname, careerW.Firstname);
            Assert.AreEqual(career.Lastname, careerW.Lastname);
            Assert.AreEqual(career.username, careerW.username);
            Assert.AreEqual(career.Color, careerW.Color);
            Assert.AreEqual(career.PhotoFileName, careerW.PhotoFileName);
            Assert.AreEqual(career.Title, careerW.Title);
            Assert.AreEqual(career.CareerInfo.AboutMe, careerW.CareerInfo.AboutMe);
            Assert.AreEqual(career.CareerInfo.Email, careerW.CareerInfo.Email);
            Assert.AreEqual(career.CareerInfo.LinkedIn, careerW.CareerInfo.LinkedIn);
            Assert.AreEqual(career.CareerInfo.Facebook, careerW.CareerInfo.Facebook);
            Assert.AreEqual(career.CareerInfo.Phone, careerW.CareerInfo.Phone);
            Assert.AreEqual(career.CareerInfo.Skype, careerW.CareerInfo.Skype);
        }
    }
}
