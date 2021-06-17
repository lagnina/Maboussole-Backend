using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class Intiateate88 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Questionnaire_questionnaireId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_AspNetUsers_KnownAsId",
                table: "Result");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_Questionnaire_questionnaireId",
                table: "Result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Result",
                table: "Result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questionnaire",
                table: "Questionnaire");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.RenameTable(
                name: "Result",
                newName: "Results");

            migrationBuilder.RenameTable(
                name: "Questionnaire",
                newName: "Questionnaires");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameIndex(
                name: "IX_Result_questionnaireId",
                table: "Results",
                newName: "IX_Results_questionnaireId");

            migrationBuilder.RenameIndex(
                name: "IX_Result_KnownAsId",
                table: "Results",
                newName: "IX_Results_KnownAsId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_questionnaireId",
                table: "Questions",
                newName: "IX_Questions_questionnaireId");

            migrationBuilder.AlterColumn<string>(
                name: "domaine",
                table: "Results",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Results",
                table: "Results",
                columns: new[] { "userId", "questionnaireId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questionnaires",
                table: "Questionnaires",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    postId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    PosterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.postId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Questionnaires_questionnaireId",
                table: "Questions",
                column: "questionnaireId",
                principalTable: "Questionnaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_AspNetUsers_KnownAsId",
                table: "Results",
                column: "KnownAsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Questionnaires_questionnaireId",
                table: "Results",
                column: "questionnaireId",
                principalTable: "Questionnaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Questionnaires_questionnaireId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_AspNetUsers_KnownAsId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Questionnaires_questionnaireId",
                table: "Results");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Results",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questionnaires",
                table: "Questionnaires");

            migrationBuilder.RenameTable(
                name: "Results",
                newName: "Result");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameTable(
                name: "Questionnaires",
                newName: "Questionnaire");

            migrationBuilder.RenameIndex(
                name: "IX_Results_questionnaireId",
                table: "Result",
                newName: "IX_Result_questionnaireId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_KnownAsId",
                table: "Result",
                newName: "IX_Result_KnownAsId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_questionnaireId",
                table: "Question",
                newName: "IX_Question_questionnaireId");

            migrationBuilder.AlterColumn<string>(
                name: "domaine",
                table: "Result",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Result",
                table: "Result",
                column: "domaine");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questionnaire",
                table: "Questionnaire",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Questionnaire_questionnaireId",
                table: "Question",
                column: "questionnaireId",
                principalTable: "Questionnaire",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_AspNetUsers_KnownAsId",
                table: "Result",
                column: "KnownAsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Questionnaire_questionnaireId",
                table: "Result",
                column: "questionnaireId",
                principalTable: "Questionnaire",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
