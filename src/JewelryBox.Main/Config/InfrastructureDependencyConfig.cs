using JewelryBox.Main.Config.Streamline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using JewelryBox.Infrastructure.ResponseHandling;
using JewelryBox.Infrastructure.Data.Contracts;
using JewelryBox.Main.Models.Infrastructure;
using JewelryBox.Infrastructure.Data.Implementations;

namespace JewelryBox.Main.Config
{
    public class InfrastructureDependencyConfig : IServiceRegistrator
    {
        public void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ITicket>()
                .To<Ticket>()
                .InTransientScope();

            //kernel.Bind<IDbFactory>()
            //    .To<JewelsDbFactory>()
            //    .InTransientScope();

            kernel.Bind<IDbFactory>()
                .To<JewelsPersistantDbFactory>()
                .InSingletonScope();

            kernel.Bind<IJewelsDbFactory>()
                .To<JewelsDbFactory>()
                .InTransientScope();

            kernel.Bind(typeof(IRepository<>))
                .To(typeof(Repository<>))
                .InTransientScope();
        }
    }
}