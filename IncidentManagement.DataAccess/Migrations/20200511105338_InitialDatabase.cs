using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentManagement.DataAccess.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Latitude = table.Column<float>(type: "float(10,6)", nullable: false),
                    Longitude = table.Column<float>(type: "float(10,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => new { x.Latitude, x.Longitude });
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Occurence = table.Column<DateTime>(nullable: false),
                    LocationLatitude = table.Column<float>(nullable: false),
                    LocationLongitude = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidents_Locations_LocationLatitude_LocationLongitude",
                        columns: x => new { x.LocationLatitude, x.LocationLongitude },
                        principalTable: "Locations",
                        principalColumns: new[] { "Latitude", "Longitude" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_LocationLatitude_LocationLongitude",
                table: "Incidents",
                columns: new[] { "LocationLatitude", "LocationLongitude" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
