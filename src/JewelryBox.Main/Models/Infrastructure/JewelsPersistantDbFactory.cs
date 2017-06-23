using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using JewelryBox.Main.Data;
using JewelryBox.Infrastructure.Data.Contracts;

namespace JewelryBox.Main.Models.Infrastructure
{
    public class JewelsPersistantDbFactory : IDbFactory
    {
        private jewelryBoxContext context;

        public DbContext Create()
        {
            if (context == null)
            {
                context = new jewelryBoxContext();
            }

            return context;
        }
    }
}