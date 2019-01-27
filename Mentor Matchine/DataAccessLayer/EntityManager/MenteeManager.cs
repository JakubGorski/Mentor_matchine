using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mentor_Matchine.Models.ViewModels;
using Mentor_Matchine.DataAccessLayer.RepositoryPattern;

namespace Mentor_Matchine.DataAccessLayer.EntityManager
{
    public class MenteeManager
    {
        private Mentor_MatchineEntities _db;
        private MenteeRepository menteeRepository;
        private MenteeLanguagesRepository menteeLanguagesRepository;

        public MenteeManager(Mentor_MatchineEntities db)
        {
            _db = db;
            menteeRepository = new MenteeRepository(_db);
            menteeLanguagesRepository = new MenteeLanguagesRepository(_db);
        }

        private int GetNextMenteeID()
        {
            var autoId = _db.Mentee.OrderByDescending(c => c.MenteeID).FirstOrDefault();
            var AutoID = autoId.MenteeID + 1;
            return AutoID;
        }

        public void AddMenteeFromForm(MenteeFormModel mentee)
        {
            //Todo - add entities to database based on the filled mentee form
            _db = new Mentor_MatchineEntities();
            var m = new Mentee();
            m.Age = mentee.Age;
            m.Name = mentee.Name;
            m.Surname = mentee.Surname;
            m.ArrivalDate = DateTime.Parse(mentee.ArrivalDate);
            m.Disability = Convert.ToByte(mentee.Disability);
            m.Gender = mentee.Gender.ToString();
            m.Email = mentee.Email;
            m.Phone = mentee.Phone;
            m.HasMentor = 0;
            //m.Nationality = mentee.Nationality; - pobrac nationality (mamy id z SelectList) i dodac do m nationalityId
            m.NationalityID = Int32.Parse(mentee.Nationality);

            var AutoID = GetNextMenteeID();

            menteeRepository.Add(m);

            foreach (string language in mentee.Languages)
            {
                var ml = new MenteeLanguage();
                //pobierac jakos prawidlowy kolejny id z bd
                ml.MenteeID = AutoID;
                System.Diagnostics.Debug.WriteLine(language.ToString());
                ml.LanguageID = Int32.Parse(language);
                menteeLanguagesRepository.Add(ml);
            }
        }
    }
}