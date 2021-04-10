using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_Manager.Models.VacationModels;

namespace Vacation_Manager.Models.UserModels
{
    public class UsersViewModel
    {
        public UsersViewModel()
        {
            Teams = new List<Teams>();
            Vacations = new List<Vacations>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public int UserTeam { get; set; }

        public virtual Teams UserTeamNavigation { get; set; }
        public virtual ICollection<Teams> Teams { get; set; }
        public virtual ICollection<Vacations> Vacations { get; set; }
    }
}
