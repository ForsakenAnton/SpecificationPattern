
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<PersonalProject> PersonalProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Developer>().HasData(
                new Developer 
                { 
                    Id = 1,
                    Name = "Anton",
                    Email = "forsakenanton@gmail.com",
                    YearsOfExperience = 1,
                    EstimatedIncome = 1000,
                });

            modelBuilder.Entity<Developer>().HasData(
                new Developer
                {
                    Id = 2,
                    Name = "ExampleName",
                    Email = "example@gmail.com",
                    YearsOfExperience = 5,
                    EstimatedIncome = 3000,
                });



            modelBuilder.Entity<PersonalProject>().HasData(new PersonalProject
            {
                Id = 1,
                ProjectName = "OnlineStore",
                ProjectStage = ProjectStage.Development,
                DeveloperId = 1,
            });

            modelBuilder.Entity<PersonalProject>().HasData(new PersonalProject
            {
                Id = 2,
                ProjectName = "SpecificationPattern",
                ProjectStage = ProjectStage.Development,
                DeveloperId = 1,
            });

            modelBuilder.Entity<PersonalProject>().HasData(new PersonalProject
            {
                Id = 3,
                ProjectName = "ExampleProject1",
                ProjectStage = ProjectStage.Development,
                DeveloperId = 2,
            });
            modelBuilder.Entity<PersonalProject>().HasData(new PersonalProject
            {
                Id = 4,
                ProjectName = "ExampleProject2",
                ProjectStage = ProjectStage.Staging,
                DeveloperId = 2,
            });
            modelBuilder.Entity<PersonalProject>().HasData(new PersonalProject
            {
                Id = 5,
                ProjectName = "ExampleProject3",
                ProjectStage = ProjectStage.Staging,
                DeveloperId = 2,
            });
            modelBuilder.Entity<PersonalProject>().HasData(new PersonalProject
            {
                Id = 6,
                ProjectName = "ExampleProject4",
                ProjectStage = ProjectStage.Production,
                DeveloperId = 2,
            });

            modelBuilder.Entity<PersonalProject>()
                .Property(e => e.DeveloperId)
                .HasDefaultValue(null);
        }
    }
}