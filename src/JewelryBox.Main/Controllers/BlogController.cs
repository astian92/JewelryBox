using JewelryBox.Infrastructure.ResponseHandling;
using JewelryBox.Main.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JewelryBox.Main.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult List()
        {
            return View();
        }

        public ActionResult GetBlogItem(string blogName)
        {
            return PartialView("Partials/BlogPost", blogName);
        }
    }
}