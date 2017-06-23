using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JewelryBox.Main.Config.Streamline
{
    public interface IServiceRegistrator
    {
        void RegisterServices(IKernel kernel);
    }
}