using JewelryBox.Infrastructure.Data.Abstractions;
using JewelryBox.Infrastructure.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryBox.Infrastructure.Data.Implementations
{
    public class Repository<TEntity> : ARepository<TEntity>
        where TEntity : class
    {
        public Repository(IDbFactory factory)
            : base(factory)
        {

        }
    }
}
