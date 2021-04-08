using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vacation_Manager.Models.Users;

namespace Vacation_Manager.Models.Vacations
{
    public class VacationViewModel
    {
        [Key]
        public int VacationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreationDate { get; set; }
        public bool? IsApproved { get; set; }
        public int VacUser { get; set; }

        public virtual UsersViewModel VacUserNavigation { get; set; }
    }
}
