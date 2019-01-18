using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mentor_Matchine.Controllers
{
    public class MenteeController : Controller
    {
        // GET: Mentee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Mentee()
        {
            // ViewBag.Message = "Your contact page."; 

            return View("Mentee");
        }
    }
}