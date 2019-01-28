using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentor_Matchine.Models.MatcherLogic
{
    public interface IMatcher
    {
        List<int> MatchMentor(MentorUser mentorUser);
        List<int> MatchMentee(MenteeUser menteeUser);
    }

    

}
