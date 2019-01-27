using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Mentor_Matchine.Models.ViewModels;
using Mentor_Matchine.DataAccessLayer;
namespace Mentor_Matchine.DataAccessLayer.EntityManager
{
    public class MentorManager
    {
        private Mentor_MatchineEntities _db;
        public void AddMentorFromForm(MentorFormModel mentor)
        {
            //todo - add Entities to database based on the filled form
            _db = new Mentor_MatchineEntities();
            var m = new Mentor();
            m.Age = mentor.Age;
            m.Name = mentor.Name;
            m.Surname = mentor.Surname;
            m.StartDate = DateTime.Parse(mentor.StartDate);
            m.Disability = Convert.ToByte(mentor.Disability);
            m.Gender = mentor.Gender.ToString();
            m.Email = mentor.Email;
            m.Phone = mentor.Phone;
            m.C_Mentees = mentor.Mentees;

            var autoId = _db.Mentor.OrderByDescending(c => c.MentorID).FirstOrDefault();
            var AutoID = autoId.MentorID + 1;

            foreach (string language in mentor.Languages)
            {
                var ml = new MentorLanguage();
                //pobierac jakos prawidlowy kolejny id z bd
                ml.MentorID = AutoID;
                System.Diagnostics.Debug.WriteLine(language.ToString());
                ml.LanguageID = Int32.Parse(language);
                _db.MentorLanguage.Add(ml);
            }
            if (mentor.Nationalities != null)
            {
                foreach (string nationality in mentor.Nationalities)
                {
                    var prefNat = new MentorPreferences();
                    prefNat.MentorID = AutoID;
                    prefNat.NationalityID = Int32.Parse(nationality);
                    _db.MentorPreferences.Add(prefNat);
                }
            }
                
            _db.Mentor.Add(m);
            _db.SaveChanges();
        }
    }
}