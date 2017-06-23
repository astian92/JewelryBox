using JewelryBox.Main.Models.Injections;
using JewelryBox.Main.Models.ViewModels;
using JewelryBox.Main.Workers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Expressions;

namespace JewelryBox.Main.Controllers
{
    public class CareersController : Controller
    {
        private readonly ICareersWorker worker;

        public CareersController(ICareersWorker worker)
        {
            this.worker = worker;
        }

        public ActionResult Person(string person)
        {
            var careerW = worker.GetCareer(person);
            return View(careerW);
        }

        [HttpGet]
        public ActionResult PersonalMessage(string username)
        {
            var model = new PersonalMessageVM()
            {
                username = username
            };

            //adds prefix to the naming in the view (needed for correct serialization)
            ViewData.TemplateInfo.HtmlFieldPrefix = "message";

            return PartialView("Partials/SendMeAMessage", model);
        }

        [HttpPost]
        public ActionResult SendPersonalMessage(PersonalMessageVM message)
        {
            if (!ModelState.IsValid)
            {
                var errorUrl = Url.Action<HomeController>(c => c.Error(500, "The state of the model is invalid!"));
                return Redirect(errorUrl);
            }

            worker.SavePersonalMessage(message);
            string actionUrl = Url.Action<CareersController>(c => c.Person(message.username));

            TempData.Add("OnMessageSucces", "Your message has been sent");

            return Redirect(actionUrl);
        }

    }
}