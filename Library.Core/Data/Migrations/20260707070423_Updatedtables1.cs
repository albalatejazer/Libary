using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updatedtables1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_ShelfLocations_ShelfId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "ShelfId",
                table: "Books",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_ShelfLocations_ShelfId",
                table: "Books",
                column: "ShelfId",
                principalTable: "ShelfLocations",
                principalColumn: "ShelfId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_ShelfLocations_ShelfId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "ShelfId",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_ShelfLocations_ShelfId",
                table: "Books",
                column: "ShelfId",
                principalTable: "ShelfLocations",
                principalColumn: "ShelfId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
