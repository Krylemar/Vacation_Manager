using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vacation_Manager
{
    public partial class Users
    {
        public Users()
        {
            Teams = new HashSet<Teams>();
            Vacations = new HashSet<Vacations>();
        }
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public int? UserTeam { get; set; }

        public virtual Teams UserTeamNavigation { get; set; }
        public virtual ICollection<Teams> Teams { get; set; }
        public virtual ICollection<Vacations> Vacations { get; set; }
    }
}
