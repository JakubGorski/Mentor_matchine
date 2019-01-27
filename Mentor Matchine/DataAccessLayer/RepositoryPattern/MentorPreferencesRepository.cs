using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mentor_Matchine.DataAccessLayer.RepositoryPattern
{
    public class MentorPreferencesRepository
    {
        private Mentor_MatchineEntities _db;

        public List<MentorPreferences> GetMentorPreferencesByID(int ID)
        {
            using (var ctx = new Mentor_MatchineEntities())
            {
                return ctx.MentorPreferences.Where(p => p.MentorID.Equals(ID)).ToList();
            }
        }
    }
}