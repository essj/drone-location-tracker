using Microsoft.EntityFrameworkCore.Migrations;

namespace DroneLocationTracker.Data.Migrations
{
    public partial class AddSpeedToLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Speed",
                table: "Locations",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Locations");
        }
    }
}
