using System;
using System.Collections.Generic;

namespace Vacation_Manager
{
    public partial class Projects
    {
        public Projects()
        {
            Teams = new HashSet<Teams>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Teams> Teams { get; set; }
    }
}
