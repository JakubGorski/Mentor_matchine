using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mentor_Matchine.DataAccessLayer.RepositoryPattern
{
    public class MenteeRepository:IRepository<Mentee>
    {
        private Mentor_MatchineEntities _db;

        public MenteeRepository(Mentor_MatchineEntities db)
        {
            _db = db;
            List = _db.Mentee;
        }
        

        public Mentee FindById(int ID)
        {
            return _db.Mentee.First(p => p.MenteeID.Equals(ID));
        }

        public IEnumerable<Mentee> List { get; }
        public void Add(Mentee entity)
        {
            _db.Mentee.Add(entity);
            _db.SaveChanges();
        }

    }
}