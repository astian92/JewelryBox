using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JewelryBox.Main.Models.Injections
{
    public static class ServiceFactory
    {
        private static IKernel kernel;

        public static void InitializeKernel(IKernel appKernel)
        {
            kernel = appKernel;
        }

        public static T GetInstance<T>()
        {
            return kernel.Get<T>();
        }

        public static object GetInstance(Type type)
        {
            return kernel.Get(type);
        }

        public static T TryGetInstance<T>()
        {
            return kernel.TryGet<T>();
        }

        public static object TryGetInstance(Type type)
        {
            return kernel.TryGet(type);
        }
    }
}