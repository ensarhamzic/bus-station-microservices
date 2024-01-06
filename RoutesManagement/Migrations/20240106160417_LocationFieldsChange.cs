using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoutesManagement.Migrations
{
    /// <inheritdoc />
    public partial class LocationFieldsChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Locations",
                newName: "City");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "Locations",
                newName: "Description");
        }
    }
}
