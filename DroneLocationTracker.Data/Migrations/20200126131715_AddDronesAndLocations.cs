using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DroneLocationTracker.Data.Migrations
{
    public partial class AddDronesAndLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(nullable: false),
                    DroneId = table.Column<Guid>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Drones",
                columns: table => new
                {
                    DroneId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastLocationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drones", x => x.DroneId);
                    table.ForeignKey(
                        name: "FK_Drones_Locations_LastLocationId",
                        column: x => x.LastLocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drones_LastLocationId",
                table: "Drones",
                column: "LastLocationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drones");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
