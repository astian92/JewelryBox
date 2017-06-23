using JewelryBox.Main.Config.Constants;
using JewelryBox.Main.Models.Injections;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace JewelryBox.Main.Config.Streamline
{
    public class ServiceRegistrator
    {
        public static void RegisterAllServices(IKernel kernel)
        {
            var registrators = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.Namespace == NamespaceConstants.Config &&
                    !t.IsInterface &&
                    !t.IsAbstract &&
                    typeof(IServiceRegistrator).IsAssignableFrom(t));

            foreach (var reg in registrators)
            {
                var instance = (IServiceRegistrator)Activator.CreateInstance(reg);
                instance.RegisterServices(kernel);
            }
        }
    }
}