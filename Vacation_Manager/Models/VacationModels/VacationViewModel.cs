using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vacation_Manager.Models.UserModels;

namespace Vacation_Manager.Models.VacationModels
{
    public class VacationViewModel
    {
        public int VacationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreationDate { get; set; }
        public bool? IsApproved { get; set; }
        public int VacUser { get; set; }

        public virtual UsersViewModel VacUserNavigation { get; set; }
    }
}
