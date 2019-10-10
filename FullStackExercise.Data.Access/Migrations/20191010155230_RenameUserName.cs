using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStackExercise.Data.Access.Migrations
{
    public partial class RenameUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Name",
                "Users");

            migrationBuilder.AddColumn<string>(
                "Username",
                "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Username",
                "Users");

            migrationBuilder.AddColumn<string>(
                "Name",
                "Users",
                "nvarchar(max)",
                nullable: true);
        }
    }
}
