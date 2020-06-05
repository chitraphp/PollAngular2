using Microsoft.EntityFrameworkCore.Migrations;

namespace PollAngular2.Migrations
{
    public partial class Createtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Poll",
                columns: table => new
                {
                    PollId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(maxLength: 500, nullable: false),
                    Voted = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poll", x => x.PollId);
                });

            migrationBuilder.CreateTable(
                name: "PollChoice",
                columns: table => new
                {
                    ChoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Choice = table.Column<string>(maxLength: 100, nullable: false),
                    Votes = table.Column<int>(nullable: false),
                    PollId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollChoice", x => x.ChoiceId);
                    table.ForeignKey(
                        name: "FK_PollChoice_Poll_PollId",
                        column: x => x.PollId,
                        principalTable: "Poll",
                        principalColumn: "PollId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PollChoice_PollId",
                table: "PollChoice",
                column: "PollId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PollChoice");

            migrationBuilder.DropTable(
                name: "Poll");
        }
    }
}
