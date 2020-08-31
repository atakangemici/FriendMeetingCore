using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Friends.Migrations
{
    public partial class migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "answering",
                table: "Replys");

            migrationBuilder.DropColumn(
                name: "reply_date",
                table: "Replys");

            migrationBuilder.CreateTable(
                name: "Respondents",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    respondent_name = table.Column<string>(nullable: true),
                    reply_date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respondents", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Respondents");

            migrationBuilder.AddColumn<string>(
                name: "answering",
                table: "Replys",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "reply_date",
                table: "Replys",
                nullable: true);
        }
    }
}
