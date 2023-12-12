using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIurlshortener.Migrations
{
    /// <inheritdoc />
    public partial class _12vaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "limite",
                table: "User",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "limite",
                table: "User");
        }
    }
}
