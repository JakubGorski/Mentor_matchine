using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mentor_Matchine.DataAccessLayer;

namespace Mentor_Matchine.DataAccessLayer.RepositoryPattern
{
    
    public class MentorRepository
    {
        private Mentor_MatchineEntities _db;

        public Mentor GetMentorByID(int ID)
        {
            using (var ctx = new Mentor_MatchineEntities())
            {
                return ctx.Mentor.First(p => p.MentorID.Equals(ID));
            }
        }
    }

}