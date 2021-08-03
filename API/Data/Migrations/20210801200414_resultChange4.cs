using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class resultChange4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Results",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_userId",
                table: "Results");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Results",
                table: "Results",
                columns: new[] { "userId", "domaine", "isMain" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Results",
                table: "Results");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Results",
                table: "Results",
                column: "domaine");

            migrationBuilder.CreateIndex(
                name: "IX_Results_userId",
                table: "Results",
                column: "userId");
        }
    }
}
