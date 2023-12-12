using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIurlshortener.Migrations
{
    /// <inheritdoc />
    public partial class TerceraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Urls",
                table: "Urls");

            migrationBuilder.RenameTable(
                name: "Urls",
                newName: "Url");

            migrationBuilder.AlterColumn<string>(
                name: "UrlShort",
                table: "Url",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID_category",
                table: "Url",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "counter",
                table: "Url",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Url",
                table: "Url",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ecommerce" },
                    { 2, "Landing" },
                    { 3, "SocialMedia" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Url_ID_category",
                table: "Url",
                column: "ID_category");

            migrationBuilder.AddForeignKey(
                name: "FK_Url_Category_ID_category",
                table: "Url",
                column: "ID_category",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Url_Category_ID_category",
                table: "Url");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Url",
                table: "Url");

            migrationBuilder.DropIndex(
                name: "IX_Url_ID_category",
                table: "Url");

            migrationBuilder.DropColumn(
                name: "ID_category",
                table: "Url");

            migrationBuilder.DropColumn(
                name: "counter",
                table: "Url");

            migrationBuilder.RenameTable(
                name: "Url",
                newName: "Urls");

            migrationBuilder.AlterColumn<string>(
                name: "UrlShort",
                table: "Urls",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Urls",
                table: "Urls",
                column: "ID");
        }
    }
}
