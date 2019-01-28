using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mentor_Matchine.Models.MatcherLogic
{
    public class EmailSender
    {
        public string Address { get; set; }

        public bool SendEmail(string address)
        {
            //Todo email sending logic
            System.Diagnostics.Debug.WriteLine("sending email to" + address);
            return true;
        }
    }
}