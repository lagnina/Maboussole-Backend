using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class Ipost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questionnaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaire", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    content = table.Column<string>(type: "TEXT", nullable: true),
                    domaine = table.Column<string>(type: "TEXT", nullable: true),
                    questionnaireId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Questionnaire_questionnaireId",
                        column: x => x.questionnaireId,
                        principalTable: "Questionnaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    domaine = table.Column<string>(type: "TEXT", nullable: false),
                    note = table.Column<int>(type: "INTEGER", nullable: false),
                    userId = table.Column<int>(type: "INTEGER", nullable: false),
                    KnownAsId = table.Column<int>(type: "INTEGER", nullable: true),
                    questionnaireId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.domaine);
                    table.ForeignKey(
                        name: "FK_Result_AspNetUsers_KnownAsId",
                        column: x => x.KnownAsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Result_Questionnaire_questionnaireId",
                        column: x => x.questionnaireId,
                        principalTable: "Questionnaire",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_questionnaireId",
                table: "Question",
                column: "questionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_KnownAsId",
                table: "Result",
                column: "KnownAsId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_questionnaireId",
                table: "Result",
                column: "questionnaireId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "Questionnaire");
        }
    }
}
