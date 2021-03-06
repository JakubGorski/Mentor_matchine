﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mentor_Matchine.DataAccessLayer.RepositoryPattern
{
    public class MentorLanguagesRepository : IRepository<MentorLanguage>
    {
        private Mentor_MatchineEntities _db;
        public IEnumerable<MentorLanguage> List { get; }

        public MentorLanguagesRepository(Mentor_MatchineEntities db)
        {
            _db = db;
            List = db.MentorLanguage;
        }

        public List<MentorLanguage> FindByIdAll(int ID)
        {
            return _db.MentorLanguage.Where(p => p.MentorID == ID).ToList();
        }

        public List<MentorLanguage> FindByLangIdAll(int ID)
        {
            var l = _db.MentorLanguage.Where(p => p.LanguageID == ID).ToList();
            //foreach(MentorLanguage ml in l)
            //{
             //   System.Diagnostics.Debug.WriteLine(ml.LanguageID +" " + ml.MentorID);
            //}
            return l;

        }

        public MentorLanguage FindById(int ID)
        {
            return _db.MentorLanguage.FirstOrDefault(p => p.MentorID.Equals(ID));
        }

        public void Add(MentorLanguage ml)
        {
            _db.MentorLanguage.Add(ml);
            _db.SaveChanges();
        }
    }
}