using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mentor_Matchine.Controllers
{
    public class MentorController : Controller
    {
        // GET: Mentor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Mentor()
        {
            //ViewBag.Message = "Your contact page.";

            return View("Mentor");
        }
    }
}