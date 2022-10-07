using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnAct.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string[]>(
                name: "StartTimes",
                table: "Groups",
                type: "text[]",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(int[]),
                oldType: "integer[]");

            migrationBuilder.AlterColumn<string[]>(
                name: "EndTimes",
                table: "Groups",
                type: "text[]",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(int[]),
                oldType: "integer[]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int[]>(
                name: "StartTimes",
                table: "Groups",
                type: "integer[]",
                nullable: false,
                oldClrType: typeof(string[]),
                oldType: "text[]",
                oldMaxLength: 7);

            migrationBuilder.AlterColumn<int[]>(
                name: "EndTimes",
                table: "Groups",
                type: "integer[]",
                nullable: false,
                oldClrType: typeof(string[]),
                oldType: "text[]",
                oldMaxLength: 7);
        }
    }
}
