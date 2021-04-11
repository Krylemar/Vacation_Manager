using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacation_Manager.Models.VacationModels
{
    public class VacationEditViewModel
    {
        public int VacationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsApprovedByCEO { get; set; }
        public string VacType { get; set; }
        public int VacUser { get; set; }

        public virtual Users VacUserNavigation { get; set; }
    }
}
