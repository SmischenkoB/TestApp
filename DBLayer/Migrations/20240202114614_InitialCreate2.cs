using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBLayer.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airport_Country_CountryId",
                table: "Airport");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_Airport_ArrivalAirportId",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_Airport_DepartureAirportId",
                table: "Route");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Route",
                table: "Route");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Airport",
                table: "Airport");

            migrationBuilder.RenameTable(
                name: "Route",
                newName: "Routes");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "Airport",
                newName: "Airports");

            migrationBuilder.RenameIndex(
                name: "IX_Route_DepartureAirportId",
                table: "Routes",
                newName: "IX_Routes_DepartureAirportId");

            migrationBuilder.RenameIndex(
                name: "IX_Route_ArrivalAirportId",
                table: "Routes",
                newName: "IX_Routes_ArrivalAirportId");

            migrationBuilder.RenameIndex(
                name: "IX_Country_Name",
                table: "Countries",
                newName: "IX_Countries_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Airport_CountryId",
                table: "Airports",
                newName: "IX_Airports_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routes",
                table: "Routes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Airports",
                table: "Airports",
                column: "AirportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Airports_Countries_CountryId",
                table: "Airports",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Airports_ArrivalAirportId",
                table: "Routes",
                column: "ArrivalAirportId",
                principalTable: "Airports",
                principalColumn: "AirportId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Airports_DepartureAirportId",
                table: "Routes",
                column: "DepartureAirportId",
                principalTable: "Airports",
                principalColumn: "AirportId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airports_Countries_CountryId",
                table: "Airports");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Airports_ArrivalAirportId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Airports_DepartureAirportId",
                table: "Routes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routes",
                table: "Routes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Airports",
                table: "Airports");

            migrationBuilder.RenameTable(
                name: "Routes",
                newName: "Route");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameTable(
                name: "Airports",
                newName: "Airport");

            migrationBuilder.RenameIndex(
                name: "IX_Routes_DepartureAirportId",
                table: "Route",
                newName: "IX_Route_DepartureAirportId");

            migrationBuilder.RenameIndex(
                name: "IX_Routes_ArrivalAirportId",
                table: "Route",
                newName: "IX_Route_ArrivalAirportId");

            migrationBuilder.RenameIndex(
                name: "IX_Countries_Name",
                table: "Country",
                newName: "IX_Country_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Airports_CountryId",
                table: "Airport",
                newName: "IX_Airport_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Route",
                table: "Route",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Airport",
                table: "Airport",
                column: "AirportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Airport_Country_CountryId",
                table: "Airport",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Route_Airport_ArrivalAirportId",
                table: "Route",
                column: "ArrivalAirportId",
                principalTable: "Airport",
                principalColumn: "AirportId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Route_Airport_DepartureAirportId",
                table: "Route",
                column: "DepartureAirportId",
                principalTable: "Airport",
                principalColumn: "AirportId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
