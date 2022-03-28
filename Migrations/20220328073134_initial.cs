using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace classProject.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Body = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Author = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommentBody = table.Column<string>(type: "TEXT", nullable: true),
                    CommentAuthor = table.Column<string>(type: "TEXT", nullable: true),
                    likes = table.Column<int>(type: "INTEGER", nullable: false),
                    CommentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "Body", "CreationDate", "Status", "Title" },
                values: new object[] { 1, "Jonas Kunert", "Post 1 bla bla bla", new DateTime(2022, 3, 28, 9, 31, 34, 446, DateTimeKind.Local).AddTicks(2070), 1, "Post no 1" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "Body", "CreationDate", "Status", "Title" },
                values: new object[] { 2, "Jonas Kunert", "Post 2 bla bla bla", new DateTime(2022, 3, 28, 9, 31, 34, 446, DateTimeKind.Local).AddTicks(2100), 1, "Post no 2" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "Body", "CreationDate", "Status", "Title" },
                values: new object[] { 3, "Jonas Kunert", "Post 3 bla bla bla", new DateTime(2022, 3, 28, 9, 31, 34, 446, DateTimeKind.Local).AddTicks(2110), 1, "Post no 3" });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "CommentId", "CommentAuthor", "CommentBody", "CommentDate", "PostId", "likes" },
                values: new object[] { 1, "Jonas", "Amazing post", new DateTime(2022, 3, 28, 9, 31, 34, 446, DateTimeKind.Local).AddTicks(2160), 1, 0 });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "CommentId", "CommentAuthor", "CommentBody", "CommentDate", "PostId", "likes" },
                values: new object[] { 2, "Jonas", "Amazing post", new DateTime(2022, 3, 28, 9, 31, 34, 446, DateTimeKind.Local).AddTicks(2170), 2, 0 });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "CommentId", "CommentAuthor", "CommentBody", "CommentDate", "PostId", "likes" },
                values: new object[] { 3, "Jonas", "Amazing post", new DateTime(2022, 3, 28, 9, 31, 34, 446, DateTimeKind.Local).AddTicks(2180), 3, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
