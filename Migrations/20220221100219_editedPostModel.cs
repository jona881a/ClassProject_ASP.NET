using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace classProject.Migrations
{
    public partial class editedPostModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Posts_Postid",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_Postid",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Postid",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Posts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PostStatus",
                table: "Posts",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Posts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Posts",
                newName: "PostStatus");

            migrationBuilder.AddColumn<int>(
                name: "Postid",
                table: "Posts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Postid",
                table: "Posts",
                column: "Postid");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Posts_Postid",
                table: "Posts",
                column: "Postid",
                principalTable: "Posts",
                principalColumn: "id");
        }
    }
}
