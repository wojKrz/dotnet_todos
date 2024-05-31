using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zajęcia1_Todos.Data.Migrations
{
    /// <inheritdoc />
    public partial class _04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Todo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Todo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
