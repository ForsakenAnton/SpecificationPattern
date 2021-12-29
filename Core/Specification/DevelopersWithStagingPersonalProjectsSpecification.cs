using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class DevelopersWithStagingPersonalProjectsSpecification : BaseSpecifcation<Developer>
    {
        public DevelopersWithStagingPersonalProjectsSpecification()
        {
            AddInclude(d => d.PersonalProjects.Where(p => p.ProjectStage == ProjectStage.Staging));
        }
    }
}
