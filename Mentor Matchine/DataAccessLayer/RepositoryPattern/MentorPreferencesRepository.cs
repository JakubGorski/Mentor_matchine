using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mentor_Matchine.DataAccessLayer.RepositoryPattern
{
    public class MentorPreferencesRepository:IRepository<MentorPreferences>
    {
        private Mentor_MatchineEntities _db;
        public IEnumerable<MentorPreferences> List { get; }

        public MentorPreferencesRepository(Mentor_MatchineEntities db)
        {
            _db = db;
            List = db.MentorPreferences;
        }

        public List<MentorPreferences> FindByIdAll(int ID)
        {
            return _db.MentorPreferences.Where(p => p.MentorID == ID).ToList();
        }

        public MentorPreferences FindById(int ID)
        {
            return _db.MentorPreferences.FirstOrDefault(p => p.MentorID.Equals(ID));
        }

        public void Add(MentorPreferences mp)
        {
            _db.MentorPreferences.Add(mp);
            _db.SaveChanges();
        }
    }
}