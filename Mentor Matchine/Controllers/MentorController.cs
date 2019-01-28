using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mentor_Matchine.Models.ViewModels;
using Mentor_Matchine.DataAccessLayer;
using Mentor_Matchine.DataAccessLayer.EntityManager;
using Mentor_Matchine.Models.MatcherLogic;
using Mentor_Matchine.DataAccessLayer.RepositoryPattern;

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
                using (var db = new Mentor_MatchineEntities())
                {
                    var mlr = new MenteeLanguagesRepository(db);
                    var mentorlr = new MentorLanguagesRepository(db);
                    var mpr = new MentorPreferencesRepository(db);
                    var matchesR = new MatchesRepository(db);
                    var mr = new MenteeRepository(db);
                    var mentorR = new MentorRepository(db);

                    var manager = new Director();
                    var builder = new SimpleMatcherBuilder();
                    manager.Construct(builder, mlr, mr, matchesR);
                    var matcher = builder.GetResult();

                    var MentorFactory = new MentorFactory(mentorlr, mpr, matcher);
                    var email = new EmailSender();

                    MentorManager mentorManager = new MentorManager(db, mentorR, mpr, mentorlr);
                    int id = mentorManager.AddMentorFromForm(mentor);

                    var mentorUser = MentorFactory.GetUser(mentorR.FindById(id));
                    mentorUser.Id = id;
                    var matches = mentorUser.Match();

                    var f = mentorR.FindById(id).C_Mentees;
                    var emails = new List<String>();
                    foreach (int i in matches)
                    {
                        emails.Add(mr.FindById(i).Email);
                        f = f - 1;
                    }
                    mentorR.FindById(id).C_Mentees = f;
                    foreach (string e in emails)
                        email.SendEmail(e);
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