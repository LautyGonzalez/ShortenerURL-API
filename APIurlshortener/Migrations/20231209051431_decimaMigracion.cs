using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIurlshortener.Migrations
{
    /// <inheritdoc />
    public partial class decimaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_user",
                table: "Url",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Url_User_UserID",
                table: "Url");

            migrationBuilder.DropIndex(
                name: "IX_Url_UserID",
                table: "Url");

            migrationBuilder.DropColumn(
                name: "ID_user",
                table: "Url");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Url");
        }
    }
}
