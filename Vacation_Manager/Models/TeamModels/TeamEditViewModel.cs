using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_Manager.Models.ProjectModels;
using Vacation_Manager.Models.UserModels;

namespace Vacation_Manager.Models.TeamModels
{
    public class TeamEditViewModel
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public Users TeamLeadNavigation { get; set; }
        public int LeaderId { get; set; }
        public int ProjectId { get; set; }
        public Projects TeamProjectNavigation { get; set; }
        public List<UsersViewModel> userItems { get; set; }
        public List<ProjectViewModel> projectItems { get; set; }
    }
}
