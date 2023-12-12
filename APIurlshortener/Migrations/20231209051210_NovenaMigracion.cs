using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIurlshortener.Migrations
{
    /// <inheritdoc />
    public partial class NovenaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Url_User_ID_user",
                table: "Url");

            migrationBuilder.DropIndex(
                name: "IX_Url_ID_user",
                table: "Url");

            migrationBuilder.DropColumn(
                name: "ID_user",
                table: "Url");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_user",
                table: "Url",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
    }
}
