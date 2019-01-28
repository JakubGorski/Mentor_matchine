using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mentor_Matchine.DataAccessLayer;
using Mentor_Matchine.DataAccessLayer.RepositoryPattern;

namespace Mentor_Matchine.Models.MatcherLogic
{
    public class MenteeFactory:UserFactory<Mentee>
    {
        private MenteeLanguagesRepository _mlr;
        private IMatcher _matcher;

        public MenteeFactory( MenteeLanguagesRepository mlr, IMatcher matcher)
        {
            _mlr = mlr;
            _matcher = matcher;
        }

        public override User GetUser(Mentee _mentee)
        {
            var mentee = new MenteeUser(_mentee.Name, _mentee.Surname, _mentee.Email, _mentee.Gender, _mentee.Disability, _matcher);
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