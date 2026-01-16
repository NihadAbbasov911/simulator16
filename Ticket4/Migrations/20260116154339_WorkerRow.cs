using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticket4.Migrations
{
    /// <inheritdoc />
    public partial class WorkerRow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_PositionId",
                table: "Workers",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Positions_PositionId",
                table: "Workers",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Positions_PositionId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_PositionId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "Workers");
        }
    }
}
