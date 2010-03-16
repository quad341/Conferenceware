using System;
using System.Web.Mvc;

namespace Conferenceware.Models
{
    public class MechmaniaTeamEditData
    {
        /// <summary>
        /// Mechmania team name
        /// </summary>
        public String team_name
        {
            get;
            set;
        }
        /// <summary>
        /// First team member's email
        /// </summary>
        public String member_email_1
        {
            get;
            set;
        }
        /// <summary>
        /// Second team member's email
        /// </summary>
        public String member_email_2
        {
            get;
            set;
        }
        /// <summary>
        /// Third team member's email
        /// </summary>
        public String member_email_3
        {
            get;
            set;
        }
    }
}
