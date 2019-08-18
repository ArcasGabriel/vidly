using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            ViewBag.Message = "Vidly movies rental shop.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us for any further information.";

            return View();
        }
    }
}