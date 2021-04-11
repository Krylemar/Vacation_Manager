using System;
using System.Collections.Generic;

namespace Vacation_Manager
{
    public partial class Teams
    {
        public Teams()
        {
            Users = new HashSet<Users>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int? TeamLead { get; set; }
        public int? TeamProject { get; set; }

        public virtual Users TeamLeadNavigation { get; set; }
        public virtual Projects TeamProjectNavigation { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
