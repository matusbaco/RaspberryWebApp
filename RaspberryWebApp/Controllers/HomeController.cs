using RaspberryWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RaspberryWebApp.Controllers
{
    public class HomeController : Controller
    {
        private RaspContext db = new RaspContext();
        public ActionResult Index()
        {

            var kkt = db.Devices.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}