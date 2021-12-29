using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int YearsOfExperience { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal EstimatedIncome { get; set; }
        public IEnumerable<PersonalProject> PersonalProjects { get; set; }
    }
}
