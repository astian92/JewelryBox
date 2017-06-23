using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryBox.Infrastructure.Data.Contracts
{
    public interface IDbFactory
    {
        DbContext Create();
    }
}
