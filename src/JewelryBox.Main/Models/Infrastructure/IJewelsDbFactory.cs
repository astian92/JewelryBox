using JewelryBox.Infrastructure.Data.Contracts;
using JewelryBox.Main.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JewelryBox.Main.Models.Infrastructure
{
    public interface IJewelsDbFactory : IDbFactory
    {
        jewelryBoxContext CreateConcrete();
    }
}