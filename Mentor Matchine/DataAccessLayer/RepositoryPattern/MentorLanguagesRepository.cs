using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mentor_Matchine.DataAccessLayer.RepositoryPattern
{
    public class MentorLanguagesRepository
    {
        private Mentor_MatchineEntities _db;

        public List<MentorLanguage> GetMentorLanguagesByID(int ID)
        {
            using (var ctx = new Mentor_MatchineEntities())
            {
                return ctx.MentorLanguage.Where(p => p.MentorID.Equals(ID)).ToList();
            }
        }
    }
}