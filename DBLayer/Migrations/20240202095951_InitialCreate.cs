using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    AirportId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IATACode = table.Column<string>(type: "TEXT", nullable: false),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.AirportId);
                    table.ForeignKey(
                        name: "FK_Airport_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartureAirportId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArrivalAirportId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Route_Airport_ArrivalAirportId",
                        column: x => x.ArrivalAirportId,
                        principalTable: "Airport",
                        principalColumn: "AirportId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Route_Airport_DepartureAirportId",
                        column: x => x.DepartureAirportId,
                        principalTable: "Airport",
                        principalColumn: "AirportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airport_CountryId",
                table: "Airport",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_Name",
                table: "Country",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Route_ArrivalAirportId",
                table: "Route",
                column: "ArrivalAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_DepartureAirportId",
                table: "Route",
                column: "DepartureAirportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Airport");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
