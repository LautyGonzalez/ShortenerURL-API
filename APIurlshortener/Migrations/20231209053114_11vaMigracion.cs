using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIurlshortener.Migrations
{
    /// <inheritdoc />
    public partial class _11vaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Url_User_UserID",
                table: "Url");

            migrationBuilder.DropIndex(
                name: "IX_Url_UserID",
                table: "Url");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Url");

            migrationBuilder.CreateIndex(
                name: "IX_Url_ID_user",
                table: "Url",
                column: "ID_user");

            migrationBuilder.AddForeignKey(
                name: "FK_Url_User_ID_user",
                table: "Url",
                column: "ID_user",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Url_User_ID_user",
                table: "Url");

            migrationBuilder.DropIndex(
                name: "IX_Url_ID_user",
                table: "Url");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Url",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Url_UserID",
                table: "Url",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Url_User_UserID",
                table: "Url",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
