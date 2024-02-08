using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBLayer.Migrations
{
    public partial class AddAirportType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AirportTypeId",
                table: "Airports",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AirportTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airports_AirportTypeId",
                table: "Airports",
                column: "AirportTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Airports_AirportTypes_AirportTypeId",
                table: "Airports",
                column: "AirportTypeId",
                principalTable: "AirportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airports_AirportTypes_AirportTypeId",
                table: "Airports");

            migrationBuilder.DropTable(
                name: "AirportTypes");

            migrationBuilder.DropIndex(
                name: "IX_Airports_AirportTypeId",
                table: "Airports");

            migrationBuilder.DropColumn(
                name: "AirportTypeId",
                table: "Airports");
        }
    }
}
