using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryBox.Infrastructure.ResponseHandling
{
    public interface ITicket
    {
        bool IsOK { get; }
        ErrorCodes Code { get; }
        string Message { get; }
        ITicket Inner { get; }
    }
}
