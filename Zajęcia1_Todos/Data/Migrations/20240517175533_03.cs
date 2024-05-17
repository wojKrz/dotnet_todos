using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zajęcia1_Todos.Data.Migrations
{
    /// <inheritdoc />
    public partial class _03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Todo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TodoGroupId",
                table: "Todo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TodoGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForDay = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoGroup", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todo_TodoGroupId",
                table: "Todo",
                column: "TodoGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_TodoGroup_TodoGroupId",
                table: "Todo",
                column: "TodoGroupId",
                principalTable: "TodoGroup",
                principalColumn: "Id");

            migrationBuilder.Sql(
                @"INSERT INTO TodoGroup (ForDay)
                    SELECT Todo.ForDay FROM Todo GROUP BY Todo.ForDay"
                );

            migrationBuilder.Sql(
                @"UPDATE Todo SET Todo.GroupId = TodoGroup.Id 
                FROM Todo INNER JOIN TodoGroup ON Todo.ForDay = TodoGroup.ForDay "
                );

            migrationBuilder.DropColumn(
                name: "ForDay",
                table: "Todo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_TodoGroup_TodoGroupId",
                table: "Todo");

            migrationBuilder.DropTable(
                name: "TodoGroup");

            migrationBuilder.DropIndex(
                name: "IX_Todo_TodoGroupId",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "TodoGroupId",
                table: "Todo");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ForDay",
                table: "Todo",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
