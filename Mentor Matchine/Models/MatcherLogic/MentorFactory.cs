using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mentor_Matchine.DataAccessLayer;
using Mentor_Matchine.DataAccessLayer.RepositoryPattern;

namespace Mentor_Matchine.Models.MatcherLogic
{
    public class MentorFactory : UserFactory
    {
        private Mentor _mentor;
        private MentorLanguagesRepository _mlr;
        private MentorPreferencesRepository _mpr;

        public MentorFactory(Mentor mentor, MentorLanguagesRepository mlr, MentorPreferencesRepository mpr)
        {
            _mentor = mentor;
            _mlr = mlr;
            _mpr = mpr;
        }

        public override User GetUser()
        {
            var mentor = new MentorUser(_mentor.Name, _mentor.Surname, _mentor.Email, _mentor.Gender, _mentor.Disability, _mentor.C_Mentees);
            if (_mentor.Age != null)
                mentor.Age = (int)_mentor.Age;
            if (_mentor.StartDate != null)
                mentor.StartDate = (System.DateTime)_mentor.StartDate;

            List<MentorLanguage> mentorLanguages = _mlr.FindByIdAll(_mentor.MentorID);
            List<int> languages = new List<int>();
            foreach (MentorLanguage ml in mentorLanguages)
            {
                languages.Add((int)ml.LanguageID);
            }
            mentor.Languages = languages;

            List<MentorPreferences> mentorPreferences = _mpr.FindByIdAll(_mentor.MentorID);
            List<int> preferences = new List<int>();
            foreach (MentorPreferences mp in mentorPreferences)
            {
                preferences.Add((int)mp.NationalityID);
            }
            mentor.PrefNationalities = preferences;

            return mentor;
        }
    }
}