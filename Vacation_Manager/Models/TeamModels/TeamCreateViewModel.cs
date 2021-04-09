using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacation_Manager.Models.TeamModels
{
    public class TeamCreateViewModel
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public virtual Users TeamLeadNavigation { get; set; }
        public virtual Projects TeamProjectNavigation { get; set; }
    }
}
