using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBorrowingStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Borrowings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Borrowings",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
