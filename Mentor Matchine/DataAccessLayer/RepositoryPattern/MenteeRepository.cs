using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mentor_Matchine.DataAccessLayer.RepositoryPattern
{
    public class MenteeRepository
    {
        private Mentor_MatchineEntities _db;

        public Mentee GetMenteeByID(int ID)
        {
            using (var ctx = new Mentor_MatchineEntities())
            {
                return ctx.Mentee.First(p => p.MenteeID.Equals(ID));
            }
        }
    }
}