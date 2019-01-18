using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mentor_Matchine.Controllers
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

/*        public ActionResult Mentor()
        {
            /*ViewBag.Message = "Your contact page.";

            return View("Mentor");
        }

        public ActionResult Mentee()
        {
            /* ViewBag.Message = "Your contact page."; 

            return View("Mentee");
        }
*/
    }
}