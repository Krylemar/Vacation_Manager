using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vacation_Manager.Models.Vacations;
using Vacation_Manager.Models.Team;

namespace Vacation_Manager.Models.Users
{
    public class UsersViewModel : IdentityUser
    {
        public UsersViewModel()
        {
            Teams = new List<TeamsViewModel>();
            Vacations = new List<VacationViewModel>();
        }
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name can be at most 50 characters long")]
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public int UserTeam { get; set; }

        public TeamsViewModel UserTeamNavigation { get; set; }
        public ICollection<TeamsViewModel> Teams { get; set; }
        public ICollection<VacationViewModel> Vacations { get; set; }

        public int UsersViewModelId { get; set; }
    }
}
