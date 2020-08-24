using Microsoft.EntityFrameworkCore.Migrations;

namespace Friends.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name_surename",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "participant_name",
                table: "Participants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name_surename",
                table: "User");

            migrationBuilder.DropColumn(
                name: "participant_name",
                table: "Participants");
        }
    }
}
