using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mentor_Matchine.DataAccessLayer;
using Mentor_Matchine.DataAccessLayer.RepositoryPattern;

namespace Mentor_Matchine.Models.MatcherLogic
{
    public class MentorFactory : UserFactory<Mentor>
    {
        private MentorLanguagesRepository _mlr;
        private MentorPreferencesRepository _mpr;
        private IMatcher _matcher;

        public MentorFactory(MentorLanguagesRepository mlr, MentorPreferencesRepository mpr, IMatcher matcher)
        {
            _mlr = mlr;
            _mpr = mpr;
            _matcher = matcher;
        }

        public override User GetUser(Mentor _mentor)
        {
            var mentor = new MentorUser(_mentor.Name, _mentor.Surname, _mentor.Email, _mentor.Gender, _mentor.Disability, _mentor.C_Mentees, _matcher);
            if (_mentor.Age != null)
            {
                System.Diagnostics.Debug.WriteLine("przed set age");
                mentor.Age = (int)_mentor.Age;
                System.Diagnostics.Debug.WriteLine("po set age");
            }
                
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