using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnAct.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Groups_ActivityId",
                table: "Groups",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_PlaceId",
                table: "Groups",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Activities_ActivityId",
                table: "Groups",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Places_PlaceId",
                table: "Groups",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Activities_ActivityId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Places_PlaceId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_ActivityId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_PlaceId",
                table: "Groups");
        }
    }
}
