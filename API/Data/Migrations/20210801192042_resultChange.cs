using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class resultChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_AspNetUsers_EmailId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Questionnaires_questionnaireId",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Results",
                table: "Results");

            //migrationBuilder.DropIndex(
            //    name: "IX_Results_EmailId",
            //    table: "Results");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "questionnaireId",
                table: "Results",
                newName: "QuestionnaireId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_questionnaireId",
                table: "Results",
                newName: "IX_Results_QuestionnaireId");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionnaireId",
                table: "Results",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "domaine",
                table: "Results",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Results",
                table: "Results",
                column: "domaine");

            migrationBuilder.CreateIndex(
                name: "IX_Results_userId",
                table: "Results",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_AspNetUsers_userId",
                table: "Results",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Questionnaires_QuestionnaireId",
                table: "Results",
                column: "QuestionnaireId",
                principalTable: "Questionnaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_AspNetUsers_userId",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Questionnaires_QuestionnaireId",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Results",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_userId",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "QuestionnaireId",
                table: "Results",
                newName: "questionnaireId");

            migrationBuilder.RenameIndex(
                name: "IX_Results_QuestionnaireId",
                table: "Results",
                newName: "IX_Results_questionnaireId");

            migrationBuilder.AlterColumn<string>(
                name: "domaine",
                table: "Results",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "questionnaireId",
                table: "Results",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmailId",
                table: "Results",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Results",
                table: "Results",
                columns: new[] { "userId", "questionnaireId" });

            migrationBuilder.CreateIndex(
                name: "IX_Results_EmailId",
                table: "Results",
                column: "EmailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_AspNetUsers_EmailId",
                table: "Results",
                column: "EmailId",
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
    }
}
