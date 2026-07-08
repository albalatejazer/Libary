using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updatedtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Borrowings");

            migrationBuilder.DropColumn(
                name: "Edition",
                table: "Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DueDate",
                table: "Borrowings",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Edition",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
