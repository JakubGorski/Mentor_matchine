using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mentor_Matchine.Models.MatcherLogic
{
    public abstract class UserFactory
    {
        public abstract User GetUser();
    }
}