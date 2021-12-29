namespace Core.Entities
{
    public class PersonalProject
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public ProjectStage ProjectStage { get; set; }

        public int? DeveloperId { get; set; }
        public Developer Developer { get; set; }
    }

    public enum ProjectStage
    {
        Development,
        Staging,
        Production,
    }
}