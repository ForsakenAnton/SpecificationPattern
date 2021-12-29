using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddColumnTypeNameEstimatedIncomeAndNullableDeveloperId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalProjects_Developers_DeveloperId",
                table: "PersonalProjects");

            migrationBuilder.AlterColumn<int>(
                name: "DeveloperId",
                table: "PersonalProjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalProjects_Developers_DeveloperId",
                table: "PersonalProjects",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalProjects_Developers_DeveloperId",
                table: "PersonalProjects");

            migrationBuilder.AlterColumn<int>(
                name: "DeveloperId",
                table: "PersonalProjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalProjects_Developers_DeveloperId",
                table: "PersonalProjects",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
