using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_Manager.Models.Users;

namespace Vacation_Manager.Models.Team
{
    public class TeamsViewModel
    {
        public TeamsViewModel()
        {
            Users = new List<UsersViewModel>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int TeamLead { get; set; }
        public int TeamProject { get; set; }

        public virtual UsersViewModel TeamLeadNavigation { get; set; }
        public virtual Projects TeamProjectNavigation { get; set; }
        public virtual ICollection<UsersViewModel> Users { get; set; }
    }
}
