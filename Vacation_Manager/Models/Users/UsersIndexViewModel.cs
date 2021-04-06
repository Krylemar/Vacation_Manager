using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacation_Manager.Models.Users
{
    public class UsersIndexViewModel
    {
        public ICollection<UsersViewModel> items { get; set; }
    }
}
