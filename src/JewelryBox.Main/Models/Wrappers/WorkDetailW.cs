using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JewelryBox.Main.Models.Wrappers
{
    public class WorkDetailW
    {
        public int Id { get; set; }
        public Guid CareerId { get; set; }
        public string Header { get; set; }
        public string Summary { get; set; }
        public string IconClass { get; set; }
    }
}