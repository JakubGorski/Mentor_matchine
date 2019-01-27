using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mentor_Matchine.Models.ViewModels;
using Mentor_Matchine.DataAccessLayer;
using Mentor_Matchine.DataAccessLayer.EntityManager;

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
            using (var db = new Mentor_MatchineEntities())
            {
                var languages = db.Lang.Select(l => new
                {
                    LangID = l.LanguageID,
                    Language = l.SpokenLang
                }).ToList();
                var nationalities = db.Nationality.Select(l => new {
                    NatID = l.NationalityID,
                    Nationality = l.Nationality1
                }).ToList();
                ViewBag.Languages = new MultiSelectList(languages, "LangID", "Language");
                ViewBag.Nationalities = new SelectList(nationalities, "NatID", "Nationality");

                return View("Mentee");
            }
        }

        [HttpPost]
        public ActionResult Mentee(MenteeFormModel mentee)
        {
            if (ModelState.IsValid)
            {
                MenteeManager menteeManager = new MenteeManager();
                menteeManager.AddMenteeFromForm(mentee);
                using (var db = new Mentor_MatchineEntities())
                {
                    var languages = db.Lang.Select(l => new
                    {
                        LangID = l.LanguageID,
                        Language = l.SpokenLang
                    }).ToList();

                    var nationalities = db.Nationality.Select(l => new {
                        NatID = l.NationalityID,
                        Nationality = l.Nationality1
                    }).ToList();
                    ViewBag.Languages = new MultiSelectList(languages, "LangID", "Language");
                    ViewBag.Nationalities = new SelectList(nationalities, "NatID", "Nationality");

                    return View("Mentee");
                }
            }
            return View("~/Views/Home/Index.cshtml");
        }
    }
}