using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mentor_Matchine.DataAccessLayer;

namespace Mentor_Matchine.DataAccessLayer.RepositoryPattern
{

    public class MentorRepository : IRepository<Mentor>
    {
        private Mentor_MatchineEntities _db;

        public MentorRepository(Mentor_MatchineEntities db)
        {
            _db = db;
            List = _db.Mentor;
        }


        public Mentor FindById(int ID)
        {
            return _db.Mentor.First(p => p.MentorID.Equals(ID));
        }

        public IEnumerable<Mentor> List { get; }
        public void Add(Mentor entity)
        {
            _db.Mentor.Add(entity);
            _db.SaveChanges();
        }
    }
}