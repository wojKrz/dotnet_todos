using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zajęcia1_Todos.Data.Migrations
{
    /// <inheritdoc />
    public partial class _05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "TodoGroup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Todo",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "TodoGroup");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Todo");
        }
    }
}
