using Microsoft.EntityFrameworkCore.Migrations;

namespace ITQJ.API.Migrations
{
    public partial class PostulantChangesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsOpen",
                table: "Projects",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "HasProyectReview",
                table: "Postulants",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasWorkReview",
                table: "Postulants",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSellected",
                table: "Postulants",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasProyectReview",
                table: "Postulants");

            migrationBuilder.DropColumn(
                name: "HasWorkReview",
                table: "Postulants");

            migrationBuilder.DropColumn(
                name: "IsSellected",
                table: "Postulants");

            migrationBuilder.AlterColumn<bool>(
                name: "IsOpen",
                table: "Projects",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);
        }
    }
}
