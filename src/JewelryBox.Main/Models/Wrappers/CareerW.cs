using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JewelryBox.Main.Models.Wrappers
{
    public class CareerW
    {
        public CareerW()
        {
            Timelines = new List<TimelineW>();
            WorkDetails = new List<WorkDetailW>();
        }

        public Guid Id { get; set; }
        public string username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; }
        public string PhotoFileName { get; set; }
        public string Color { get; set; }

        public virtual CareerInfoW CareerInfo { get; set; }
        public virtual ICollection<TimelineW> Timelines { get; set; }
        public virtual ICollection<WorkDetailW> WorkDetails { get; set; }
    }
}