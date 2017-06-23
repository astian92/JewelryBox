using JewelryBox.Main.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryBox.Main.Tests.Models
{
    public class Populator
    {
        public Career GetCareer(string username)
        {
            return new Career()
            {
                Id = Guid.NewGuid(),
                Firstname = "FirstName",
                Lastname = "LastName",
                username = username,
                PhotoFileName = "photo.png",
                Color = "#322332",
                Title = "King of the testings",
                CareerInfo = new CareerInfo()
                {
                    Email = "sad@gmail.com",
                    AboutMe = "No test left behins!",
                    Facebook = "fb",
                    LinkedIn = "ln",
                    Phone = "Sony ericson",
                    Skype = "sadler"
                }
            };
        }

        public IEnumerable<Career> GetCareers(int number)
        {
            var result = new List<Career>();

            for (int i = 0; i < number; i++)
            {
                var career = new Career()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "FirstName" + i,
                    Lastname = "LastName" + i,
                    username = "username" + i,
                    PhotoFileName = "photo.png" + i,
                    Color = "#322332" + i,
                    Title = "King of the testings" + i,
                    CareerInfo = new CareerInfo()
                    {
                        Email = "sad@gmail.com" + i,
                        AboutMe = "No test left behins!" + i,
                        Facebook = "fb" + i,
                        LinkedIn = "ln" + i,
                        Phone = "Sony ericson" + i,
                        Skype = "sadler" + i
                    }
                };

                result.Add(career);
            }

            return result;
        }
    }
}
