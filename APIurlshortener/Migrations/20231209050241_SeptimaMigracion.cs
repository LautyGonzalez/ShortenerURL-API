using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIurlshortener.Migrations
{
    /// <inheritdoc />
    public partial class SeptimaMigracion : Migration
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

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

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

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Url_ID_user",
                table: "Url");

            migrationBuilder.DropColumn(
                name: "ID_user",
                table: "Url");
        }
    }
}
