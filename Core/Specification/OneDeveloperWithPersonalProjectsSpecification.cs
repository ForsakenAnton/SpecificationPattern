using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class OneDeveloperWithPersonalProjectsSpecification : BaseSpecifcation<Developer>
    {
        public OneDeveloperWithPersonalProjectsSpecification(int id) : base(d => d.Id == id)
        {
            AddInclude(x => x.PersonalProjects);
        }
    }
}
