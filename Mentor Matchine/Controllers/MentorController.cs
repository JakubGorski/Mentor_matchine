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
    public class MentorController : Controller
    {
        
        // GET: Mentor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Mentor()
        {
            using (var db = new Mentor_MatchineEntities())
            {
                var languages = db.Lang.Select(l => new {
                    LangID = l.LanguageID,
                    Language = l.SpokenLang
                }).ToList();
                var nationalities = db.Nationality.Select(l => new {
                    NatID = l.NationalityID,
                    Nationality = l.Nationality1
                }).ToList();
                ViewBag.Languages = new MultiSelectList(languages, "LangID", "Language");
                ViewBag.Nationalities = new MultiSelectList(nationalities, "NatID", "Nationality");

                return View("Mentor");
            }
        }

        [HttpPost]
        public ActionResult Mentor(MentorFormModel mentor)
        {
            if (ModelState.IsValid)
            {
                //TODO: save data in db
                MentorManager mentorManager = new MentorManager();
                mentorManager.AddMentorFromForm(mentor);
                using (var db = new Mentor_MatchineEntities())
                {
                    var languages = db.Lang.Select(l => new {
                        LangID = l.LanguageID,
                        Language = l.SpokenLang
                    }).ToList();
                    var nationalities = db.Nationality.Select(l => new {
                        NatID = l.NationalityID,
                        Nationality = l.Nationality1
                    }).ToList();
                    ViewBag.Languages = new MultiSelectList(languages, "LangID", "Language");
                    ViewBag.Nationalities = new MultiSelectList(nationalities, "NatID", "Nationality");
                    return View("Mentor");
                }
            }

            return View("~/Views/Home/Index.cshtml");
        }
    }
}