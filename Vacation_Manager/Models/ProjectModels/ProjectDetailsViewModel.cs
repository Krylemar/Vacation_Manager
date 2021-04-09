using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vacation_Manager.Models.ProjectModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel()
        {
            Teams = new List<Teams>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public virtual ICollection<Teams> Teams { get; set; }
    }
}
