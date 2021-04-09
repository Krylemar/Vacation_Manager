using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vacation_Manager.Models.UserModels
{
    public class UsersCreateViewModel
    {

        public string Username { get; set; }
        public string Password { get; set; }       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public int Team { get; set; }
    }
}
