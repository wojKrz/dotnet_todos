using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zajęcia1_Todos.Data.Migrations
{
    /// <inheritdoc />
    public partial class _02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "ForDay",
                table: "Todo",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(2024, 05, 17));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForDay",
                table: "Todo");
        }
    }
}
