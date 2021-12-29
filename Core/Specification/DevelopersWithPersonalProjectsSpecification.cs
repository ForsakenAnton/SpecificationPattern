using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class DevelopersWithPersonalProjectsSpecification : BaseSpecifcation<Developer>
    {
        public DevelopersWithPersonalProjectsSpecification(int years = 0) : base(x => x.YearsOfExperience >= years)
        {
            AddInclude(x => x.PersonalProjects);
        }
    }
}
