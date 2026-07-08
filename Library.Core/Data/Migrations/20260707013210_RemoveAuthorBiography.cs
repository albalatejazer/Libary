using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAuthorBiography : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Biography",
                table: "Authors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "Authors",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
