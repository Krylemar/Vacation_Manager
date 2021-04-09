using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacation_Manager.Models.UserModels
{
    public class UsersIndexViewModel
    {
        public ICollection<UsersViewModel> items { get; set; }
    }
}
