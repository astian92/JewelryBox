using JewelryBox.Main.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JewelryBox.Main.Services.Implementations
{
    public class RandomService : IRandomService
    {
        public int RandomNumber()
        {
            return new Random().Next(0, 100);
        }
    }
}