using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mentor_Matchine.DataAccessLayer;
using Mentor_Matchine.DataAccessLayer.RepositoryPattern;

namespace Mentor_Matchine.Models.MatcherLogic
{
    public class MenteeFactory:UserFactory
    {
        private Mentee _mentee;
        private MenteeLanguagesRepository _mlr;

        public MenteeFactory(Mentee mentee, MenteeLanguagesRepository mlr)
        {
            _mentee = mentee;
            _mlr = mlr;
        }

        public override User GetUser()
        {
            var mentee = new MenteeUser(_mentee.Name, _mentee.Surname, _mentee.Email, _mentee.Gender, _mentee.Disability);
            if (_mentee.Age != null)
                mentee.Age = (int)_mentee.Age;
            if (_mentee.NationalityID != null)
                mentee.Nationality = (int)_mentee.NationalityID;
            if (_mentee.ArrivalDate != null)
                mentee.ArrivalDate = (System.DateTime)_mentee.ArrivalDate;
            List<MenteeLanguage> menteeLanguages = _mlr.FindByIdAll(_mentee.MenteeID);
            List<int> languages = new List<int>();
            foreach(MenteeLanguage ml in menteeLanguages)
            {
                languages.Add((int)ml.LanguageID);
            }
            mentee.Languages = languages;
            return mentee;
        }
    }
}