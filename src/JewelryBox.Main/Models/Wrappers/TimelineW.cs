using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JewelryBox.Main.Models.Wrappers
{
    public class TimelineW
    {
        public int Id { get; set; }
        public Guid CareerId { get; set; }
        public int Year { get; set; }
        public string Event { get; set; }
    }
}