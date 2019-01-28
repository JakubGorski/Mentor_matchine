using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Mentor_Matchine.Models.ViewModels;
using Mentor_Matchine.DataAccessLayer;
using Mentor_Matchine.DataAccessLayer.RepositoryPattern;

namespace Mentor_Matchine.DataAccessLayer.EntityManager
{ 
    public class MentorManager
    {
        private Mentor_MatchineEntities _db;
        private MentorRepository mentorRepository;
        private MentorLanguagesRepository mentorLanguagesRepository;
        private MentorPreferencesRepository mentorPreferencesRepository;

        public MentorManager(Mentor_MatchineEntities db, MentorRepository mr, MentorPreferencesRepository mpr, MentorLanguagesRepository mlr)
        {
            _db = db;
            mentorRepository = mr;
            mentorPreferencesRepository = mpr;
            mentorLanguagesRepository = mlr;
        }
        
        private int GetNextMentorID()
        {
            var autoId = _db.Mentor.OrderByDescending(c => c.MentorID).FirstOrDefault();
            var AutoID = autoId.MentorID + 1;
            return AutoID;
        }
        public int AddMentorFromForm(MentorFormModel mentor)
        {
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

            var AutoID = GetNextMentorID();
            mentorRepository.Add(m);

            foreach (string language in mentor.Languages)
            {
                var ml = new MentorLanguage();
                ml.MentorID = AutoID;
                System.Diagnostics.Debug.WriteLine(language.ToString());
                ml.LanguageID = Int32.Parse(language);
                mentorLanguagesRepository.Add(ml);
            }
            if (mentor.Nationalities != null)
            {
                foreach (string nationality in mentor.Nationalities)
                {
                    var prefNat = new MentorPreferences();
                    prefNat.MentorID = AutoID;
                    prefNat.NationalityID = Int32.Parse(nationality);
                    mentorPreferencesRepository.Add(prefNat);
                }
            }
            return AutoID;
            
        }
    }
}