using Mentor_Matchine.Models.MatcherLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mentor_Matchine.DataAccessLayer.RepositoryPattern
{
    public class MenteeLanguagesRepository:IRepository<MenteeLanguage>
    {
        private Mentor_MatchineEntities _db;
        public IEnumerable<MenteeLanguage> List { get; }

        public MenteeLanguagesRepository(Mentor_MatchineEntities db)
        {
            _db = db;
            List = db.MenteeLanguage;
        }

        public List<MenteeLanguage> FindByIdAll(int ID)
        {
            return _db.MenteeLanguage.Where(p => p.MenteeID.Equals(ID)).ToList();
        }

        public List<MenteeLanguage> FindByLangIdAll(int ID)
        {
            return _db.MenteeLanguage.Where(p => p.LanguageID==ID).ToList();
        }

        public MenteeLanguage FindById(int ID)
        {
            return _db.MenteeLanguage.FirstOrDefault(p => p.MenteeID.Equals(ID));
        }

        public void Add(MenteeLanguage ml)
        {
            _db.MenteeLanguage.Add(ml);
            _db.SaveChanges();
        }
    }
}