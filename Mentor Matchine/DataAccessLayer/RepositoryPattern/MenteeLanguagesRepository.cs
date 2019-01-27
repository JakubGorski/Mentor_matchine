using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mentor_Matchine.DataAccessLayer.RepositoryPattern
{
    public class MenteeLanguagesRepository
    {
        private Mentor_MatchineEntities _db;

        public List<MenteeLanguage> GetMenteeLanguagesByID(int ID)
        {
            using (var ctx = new Mentor_MatchineEntities())
            {
                return ctx.MenteeLanguage.Where(p => p.MenteeID.Equals(ID)).ToList();
            }
        }
    }
}