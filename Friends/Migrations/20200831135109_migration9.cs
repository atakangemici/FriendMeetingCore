using Microsoft.EntityFrameworkCore.Migrations;

namespace Friends.Migrations
{
    public partial class migration9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Replys",
                newName: "respondent_id");

            migrationBuilder.AddColumn<string>(
                name: "question",
                table: "Replys",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "subject",
                table: "Replys",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "question",
                table: "Replys");

            migrationBuilder.DropColumn(
                name: "subject",
                table: "Replys");

            migrationBuilder.RenameColumn(
                name: "respondent_id",
                table: "Replys",
                newName: "user_id");
        }
    }
}
