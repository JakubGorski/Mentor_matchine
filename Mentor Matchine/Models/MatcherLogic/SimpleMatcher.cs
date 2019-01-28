using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mentor_Matchine.DataAccessLayer;
using Mentor_Matchine.DataAccessLayer.RepositoryPattern;

namespace Mentor_Matchine.Models.MatcherLogic
{
    public class SimpleMatcher:IMatcher
    {
        private MenteeRepository _menteer;
        private MenteeLanguagesRepository _menteelr;
        private MatchesRepository _matches;
        private MentorRepository _mentorR;

        public MenteeRepository MenteeR
        {
            get { return _menteer; }
            set { _menteer = value; }
        }
        public MentorRepository MentorR
        {
            get { return _mentorR; }
            set { _mentorR = value; }
        }
        public MenteeLanguagesRepository MenteelR
        {
            get { return _menteelr; }
            set { _menteelr = value; }
        }
        public MatchesRepository MatchesR
        {
            get { return _matches; }
            set { _matches = value;  }
        }
        public List<int> MatchMentee(MenteeUser mentee)
        {
            return null;
        }
        public List<int> MatchMentor(MentorUser mentor)
        {
            List<int> matched = new List<int>(mentor.Mentees);
            List<User> mentees = new List<User>(mentor.Mentees);

            int k = 0;
            foreach ( int i in mentor.Languages)
            {
                var l = MenteelR.FindByLangIdAll(i);
                if (l != null)
                {
                    foreach (MenteeLanguage ml in l)
                    {
                        if (MenteeR.FindById((int)ml.MenteeID).HasMentor == 0) { 
                            matched.Add((int)ml.MenteeID);
                            MenteeR.FindById((int)ml.MenteeID).HasMentor = 1;
                            // dodac info do tablicy matches
                            var match = new Matches();
                            match.MenteeID = ml.MenteeID;
                            match.MentorID = mentor.Id;
                            MatchesR.Add(match);
                            k++;
                            return matched;
                        }     
                    }

                }
            }
            return matched;
                
        } 
           
    }
}