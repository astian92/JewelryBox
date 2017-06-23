﻿using JewelryBox.Main.Config.Streamline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Extensions.Conventions;
using JewelryBox.Main.Config.Constants;

namespace JewelryBox.Main.Config
{
    public class ServicesDependencyConfig : IServiceRegistrator
    {
        public void RegisterServices(IKernel kernel)
        {
            kernel.Bind(x => x
                .From(GetType().Assembly)
                .SelectAllClasses().InNamespaces(NamespaceConstants.Services)
                .BindAllInterfaces()
                .Configure(b => b.InTransientScope()));
        }
    }
}