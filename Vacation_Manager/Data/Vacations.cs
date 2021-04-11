using System;
using System.Collections.Generic;

namespace Vacation_Manager
{
    public partial class Vacations
    {
        public int VacationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreationDate { get; set; }
        public bool? IsApproved { get; set; }
        public int VacUser { get; set; }
        public string VacType { get; set; }
        public bool? IsApprovedByCeo { get; set; }

        public virtual Users VacUserNavigation { get; set; }
    }
}
