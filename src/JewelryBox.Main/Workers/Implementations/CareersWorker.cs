using JewelryBox.Main.Workers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JewelryBox.Main.Models.Wrappers;
using JewelryBox.Infrastructure.Data.Contracts;
using JewelryBox.Main.Data;
using JewelryBox.Main.Models.ViewModels;

namespace JewelryBox.Main.Workers.Implementations
{
    public class CareersWorker : ICareersWorker
    {
        private readonly IRepository<Career> rep;

        public CareersWorker(IRepository<Career> repository)
        {
            rep = repository;
        }

        public CareerW GetCareer(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("A correct username is required!");
            }

            username = username.ToLower();
            var allCareers = rep.GetAll();

            if (!allCareers.Any(u => u.username == username))
            {
                throw new ArgumentException("There is no username with this name in the database!");
            }

            var career = allCareers.Single(c => c.username == username);

            var careerW = new CareerW()
            {
                Id = career.Id,
                Firstname = career.Firstname,
                Lastname = career.Lastname,
                username = career.username,
                Title = career.Title,
                PhotoFileName = career.PhotoFileName,
                Color = career.Color                
            };

            if (career.CareerInfo != null)
            {
                careerW.CareerInfo = new CareerInfoW()
                {
                    AboutMe = career.CareerInfo.AboutMe,
                    Email = career.CareerInfo.Email,
                    Facebook = career.CareerInfo.Facebook,
                    LinkedIn = career.CareerInfo.LinkedIn,
                    Phone = career.CareerInfo.Phone,
                    Skype = career.CareerInfo.Skype
                };
            }

            foreach (var time in career.Timelines)
            {
                var timeline = new TimelineW()
                {
                    Year = time.Year,
                    Event = time.Event
                };

                careerW.Timelines.Add(timeline);
            }

            foreach (var work in career.WorkDetails)
            {
                var workDetail = new WorkDetailW()
                {
                    Header = work.Header,
                    Summary = work.Summary,
                    IconClass = work.IconClass
                };

                careerW.WorkDetails.Add(workDetail);
            }

            return careerW;
        }

        public void SavePersonalMessage(PersonalMessageVM message)
        {
            var visitorMessage = new VisitorMessage()
            {
                SenderName = message.Name,
                SenderEmailAddress = message.Email,
                Message = message.Message
            };

            var career = rep.GetAll().Single(c => c.username == message.username);
            career.VisitorMessages.Add(visitorMessage);

            rep.Save();
        }
    }
}