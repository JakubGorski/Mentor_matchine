using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mentor_Matchine.DataAccessLayer.RepositoryPattern
{
    public class MatchesRepository: IRepository<Matches>
    {
        private Mentor_MatchineEntities _db;

        public MatchesRepository(Mentor_MatchineEntities db)
        {
            _db = db;
            List = _db.Matches;
        }

        public IEnumerable<Matches> List { get; }

        public Matches FindById(int ID)
        {
            return _db.Matches.First(p => p.MentorID.Equals(ID));
        }

        public void Add(Matches entity)
        {
            _db.Matches.Add(entity);
            _db.SaveChanges();
        }
    }
}