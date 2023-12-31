using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoutesManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Locations_FromLocationId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Locations_ToLocationId",
                table: "Routes");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Routes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Locations_FromLocationId",
                table: "Routes",
                column: "FromLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Locations_ToLocationId",
                table: "Routes",
                column: "ToLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Locations_FromLocationId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Locations_ToLocationId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Routes");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Locations_FromLocationId",
                table: "Routes",
                column: "FromLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Locations_ToLocationId",
                table: "Routes",
                column: "ToLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
