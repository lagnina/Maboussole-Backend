using Microsoft.EntityFrameworkCore.Migrations;

namespace API.data.migrations
{
    public partial class yarbi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_AppUserId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PhotoDto_PhotosId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "PhotoDto");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PhotosId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PhotosId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Photos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Photos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PostId",
                table: "Photos",
                column: "PostId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AspNetUsers_AppUserId",
                table: "Photos",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Posts_PostId",
                table: "Photos",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "postId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_AppUserId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Posts_PostId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_PostId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Photos");

            migrationBuilder.AddColumn<int>(
                name: "PhotosId",
                table: "Posts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Photos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PhotoDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoDto", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PhotosId",
                table: "Posts",
                column: "PhotosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AspNetUsers_AppUserId",
                table: "Photos",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PhotoDto_PhotosId",
                table: "Posts",
                column: "PhotosId",
                principalTable: "PhotoDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
