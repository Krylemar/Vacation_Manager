using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacation_Manager.Models.TeamModels
{
    public class TeamViewModel
    {
        public TeamViewModel()
        {
            Users = new List<Users>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int TeamLead { get; set; }
        public int TeamProject { get; set; }

        public virtual Users TeamLeadNavigation { get; set; }
        public string NameOutput { get; set; }
        public virtual Projects TeamProjectNavigation { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
