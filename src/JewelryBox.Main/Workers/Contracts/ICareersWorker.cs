using JewelryBox.Infrastructure.ResponseHandling;
using JewelryBox.Main.Models.ViewModels;
using JewelryBox.Main.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JewelryBox.Main.Workers.Contracts
{
    public interface ICareersWorker
    {
        CareerW GetCareer(string username);
        void SavePersonalMessage(PersonalMessageVM message);
    }
}