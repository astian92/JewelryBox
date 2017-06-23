using JewelryBox.Infrastructure.ResponseHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JewelryBox.Main.Models.Infrastructure
{
    public class InfoTicket : Ticket
    {
        public InfoTicket(bool status)
            : base(status)
        {

        }

        public InfoTicket(bool status, object data)
            : base(status)
        {
            ResultData = data;
        }

        public object ResultData { get; }
    }
}