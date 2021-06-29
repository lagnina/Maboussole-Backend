using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class likedPostEntityAddedd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostLike_AspNetUsers_SourceUserId",
                table: "PostLike");

            migrationBuilder.DropForeignKey(
                name: "FK_PostLike_Posts_LikedPostId",
                table: "PostLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostLike",
                table: "PostLike");

            migrationBuilder.RenameTable(
                name: "PostLike",
                newName: "PostLikes");

            migrationBuilder.RenameIndex(
                name: "IX_PostLike_LikedPostId",
                table: "PostLikes",
                newName: "IX_PostLikes_LikedPostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostLikes",
                table: "PostLikes",
                columns: new[] { "SourceUserId", "LikedPostId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostLikes_AspNetUsers_SourceUserId",
                table: "PostLikes",
                column: "SourceUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostLikes_Posts_LikedPostId",
                table: "PostLikes",
                column: "LikedPostId",
                principalTable: "Posts",
                principalColumn: "postId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostLikes_AspNetUsers_SourceUserId",
                table: "PostLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_PostLikes_Posts_LikedPostId",
                table: "PostLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostLikes",
                table: "PostLikes");

            migrationBuilder.RenameTable(
                name: "PostLikes",
                newName: "PostLike");

            migrationBuilder.RenameIndex(
                name: "IX_PostLikes_LikedPostId",
                table: "PostLike",
                newName: "IX_PostLike_LikedPostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostLike",
                table: "PostLike",
                columns: new[] { "SourceUserId", "LikedPostId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostLike_AspNetUsers_SourceUserId",
                table: "PostLike",
                column: "SourceUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostLike_Posts_LikedPostId",
                table: "PostLike",
                column: "LikedPostId",
                principalTable: "Posts",
                principalColumn: "postId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
