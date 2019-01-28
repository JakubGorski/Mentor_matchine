using Mentor_Matchine.DataAccessLayer.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mentor_Matchine.Models.MatcherLogic
{

    public class Director

    {
        public void Construct(MatcherBuilder builder, MenteeLanguagesRepository mlr, MenteeRepository mr, MatchesRepository matches)

        {
            builder.BuildMenteeRep(mr);
            builder.BuildMLRep(mlr);
            builder.BuildMatchesR(matches);
        }

    }
    public abstract class MatcherBuilder

    {

        public abstract void BuildMenteeRep(MenteeRepository mr);

        public abstract void BuildMLRep(MenteeLanguagesRepository mlr);

        public abstract void BuildMatchesR(MatchesRepository matches);

        public abstract IMatcher GetResult();

    }
    public class SimpleMatcherBuilder:MatcherBuilder
    {
        private SimpleMatcher _SimpleMatcher = new SimpleMatcher();

        public override void BuildMenteeRep( MenteeRepository mr)
        {
            _SimpleMatcher.MenteeR = mr;
        }
        public override void BuildMLRep(MenteeLanguagesRepository mlr)
        {
            _SimpleMatcher.MenteelR = mlr;
        }

        public override void BuildMatchesR(MatchesRepository matches)
        {
            _SimpleMatcher.MatchesR = matches;
        }

        public override IMatcher GetResult()
        {
            return _SimpleMatcher;
        }

         
    }
}