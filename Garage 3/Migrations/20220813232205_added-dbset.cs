using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_3.Migrations
{
    public partial class addeddbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parking_Vehicle_VehicleId",
                table: "Parking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parking",
                table: "Parking");

            migrationBuilder.RenameTable(
                name: "Parking",
                newName: "Parkings");

            migrationBuilder.RenameIndex(
                name: "IX_Parking_VehicleId",
                table: "Parkings",
                newName: "IX_Parkings_VehicleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parkings",
                table: "Parkings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parkings_Vehicle_VehicleId",
                table: "Parkings",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parkings_Vehicle_VehicleId",
                table: "Parkings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parkings",
                table: "Parkings");

            migrationBuilder.RenameTable(
                name: "Parkings",
                newName: "Parking");

            migrationBuilder.RenameIndex(
                name: "IX_Parkings_VehicleId",
                table: "Parking",
                newName: "IX_Parking_VehicleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parking",
                table: "Parking",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parking_Vehicle_VehicleId",
                table: "Parking",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id");
        }
    }
}
