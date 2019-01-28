using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mentor_Matchine.Models.MatcherLogic
{
    public abstract class User
    {
        public abstract IMatcher Matcher { get; set; }

        public abstract string Name { get; set; }
        public abstract string Surame { get; set; }
        public abstract int Age { get; set; }
        public abstract string Email { get; set; }
        public abstract string Gender { get; set; }
        public abstract byte Disability { get; set; }
        public abstract List<int> Languages { get; set; }
        public abstract int Id { get; set; }
        public abstract List<int> Match();
    }
}