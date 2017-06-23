using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using JewelryBox.Main.Data;

namespace JewelryBox.Main.Models.Infrastructure
{
    public class JewelsDbFactory : IJewelsDbFactory
    {
        public DbContext Create()
        {
            return CreateConcrete();
        }

        public jewelryBoxContext CreateConcrete()
        {
            return new jewelryBoxContext();
        }
    }
}