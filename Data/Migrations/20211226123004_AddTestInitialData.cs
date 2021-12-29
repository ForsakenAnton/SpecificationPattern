using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddTestInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Email", "EstimatedIncome", "Name", "YearsOfExperience" },
                values: new object[] { 1, "forsakenanton@gmail.com", 1000m, "Anton", 1 });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Email", "EstimatedIncome", "Name", "YearsOfExperience" },
                values: new object[] { 2, "example@gmail.com", 3000m, "ExampleName", 5 });

            migrationBuilder.InsertData(
                table: "PersonalProjects",
                columns: new[] { "Id", "DeveloperId", "ProjectName", "ProjectStage" },
                values: new object[,]
                {
                    { 1, 1, "OnlineStore", 0 },
                    { 2, 1, "SpecificationPattern", 0 },
                    { 3, 2, "ExampleProject1", 0 },
                    { 4, 2, "ExampleProject2", 1 },
                    { 5, 2, "ExampleProject3", 1 },
                    { 6, 2, "ExampleProject4", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonalProjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PersonalProjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PersonalProjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PersonalProjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PersonalProjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PersonalProjects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
