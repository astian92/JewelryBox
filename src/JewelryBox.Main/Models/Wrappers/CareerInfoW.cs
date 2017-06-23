using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JewelryBox.Main.Models.Wrappers
{
    public class CareerInfoW
    {
        public Guid CareerId { get; set; }
        public string AboutMe { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Skype { get; set; }
    }
}