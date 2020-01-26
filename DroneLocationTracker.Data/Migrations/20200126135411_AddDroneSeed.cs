using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DroneLocationTracker.Data.Migrations
{
    public partial class AddDroneSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Drones",
                columns: new[] { "DroneId", "LastLocationId", "Name" },
                values: new object[] { new Guid("f358be15-2e6f-4235-802a-27ca93a5fef7"), null, "Test Drone 1" });

            migrationBuilder.InsertData(
                table: "Drones",
                columns: new[] { "DroneId", "LastLocationId", "Name" },
                values: new object[] { new Guid("5dee1226-3865-45de-aa97-e0d9f80ab51f"), null, "Test Drone 2" });

            migrationBuilder.InsertData(
                table: "Drones",
                columns: new[] { "DroneId", "LastLocationId", "Name" },
                values: new object[] { new Guid("4e8873e5-09d5-4eee-8602-e6f6046daaad"), null, "Test Drone 3" });

            migrationBuilder.InsertData(
                table: "Drones",
                columns: new[] { "DroneId", "LastLocationId", "Name" },
                values: new object[] { new Guid("81372f59-1cd0-4577-9d7d-ad04d1e35e99"), null, "Test Drone 4" });

            migrationBuilder.InsertData(
                table: "Drones",
                columns: new[] { "DroneId", "LastLocationId", "Name" },
                values: new object[] { new Guid("aa2252b6-7f41-41a1-9d5a-bd8b4064fd39"), null, "Test Drone 5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drones",
                keyColumn: "DroneId",
                keyValue: new Guid("4e8873e5-09d5-4eee-8602-e6f6046daaad"));

            migrationBuilder.DeleteData(
                table: "Drones",
                keyColumn: "DroneId",
                keyValue: new Guid("5dee1226-3865-45de-aa97-e0d9f80ab51f"));

            migrationBuilder.DeleteData(
                table: "Drones",
                keyColumn: "DroneId",
                keyValue: new Guid("81372f59-1cd0-4577-9d7d-ad04d1e35e99"));

            migrationBuilder.DeleteData(
                table: "Drones",
                keyColumn: "DroneId",
                keyValue: new Guid("aa2252b6-7f41-41a1-9d5a-bd8b4064fd39"));

            migrationBuilder.DeleteData(
                table: "Drones",
                keyColumn: "DroneId",
                keyValue: new Guid("f358be15-2e6f-4235-802a-27ca93a5fef7"));
        }
    }
}
