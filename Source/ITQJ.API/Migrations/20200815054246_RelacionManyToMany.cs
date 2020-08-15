using Microsoft.EntityFrameworkCore.Migrations;

namespace ITQJ.API.Migrations
{
    public partial class RelacionManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProfesionalSkills_SkillId",
                table: "ProfesionalSkills");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfesionalSkills_SkillId",
                table: "ProfesionalSkills",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_ProfesionalSkills_SkillId",
                table: "ProfesionalSkills");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesionalSkills_SkillId",
                table: "ProfesionalSkills",
                column: "SkillId",
                unique: true);
        }
    }
}
