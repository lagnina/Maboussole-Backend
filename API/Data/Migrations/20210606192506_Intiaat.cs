using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class Intiaat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Groups_GroupName",
                table: "Connections");

            migrationBuilder.RenameColumn(
                name: "LookingFor",
                table: "AspNetUsers",
                newName: "Speciality");

            migrationBuilder.RenameColumn(
                name: "Introduction",
                table: "AspNetUsers",
                newName: "Segree");

            migrationBuilder.RenameColumn(
                name: "Interests",
                table: "AspNetUsers",
                newName: "School");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Groups_GroupName",
                table: "Connections",
                column: "GroupName",
                principalTable: "Groups",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Connections_Groups_GroupName",
                table: "Connections");

            migrationBuilder.RenameColumn(
                name: "Speciality",
                table: "AspNetUsers",
                newName: "LookingFor");

            migrationBuilder.RenameColumn(
                name: "Segree",
                table: "AspNetUsers",
                newName: "Introduction");

            migrationBuilder.RenameColumn(
                name: "School",
                table: "AspNetUsers",
                newName: "Interests");

            migrationBuilder.AddForeignKey(
                name: "FK_Connections_Groups_GroupName",
                table: "Connections",
                column: "GroupName",
                principalTable: "Groups",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
