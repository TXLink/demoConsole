using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace TestAsync.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult GetMsg1()
        {
            Thread.Sleep(2000);
            return Content("Message 1");
        }

        public ActionResult GetMsg2()
        {
            Thread.Sleep(6000);
            return Content("Message 2222222");
        }
    }
}