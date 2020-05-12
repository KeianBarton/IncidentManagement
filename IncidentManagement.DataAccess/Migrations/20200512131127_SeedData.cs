using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace IncidentManagement.DataAccess.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Locations",
                columns: new [] { "Latitude", "Longitude" },
                values: new object[] { 51.500930, -0.124668 }
            );

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 51.508065, -0.087728 }
            );

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "Title", "Description", "Occurrence", "LocationLatitude", "LocationLongitude" },
                values: new object[] { "Flood at Big Ben", "Big Ben is flooded with water!", new DateTime(2020, 1, 1, 12, 0, 0), 51.500930, -0.124668 }
            );

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "Title", "Description", "Occurrence", "LocationLatitude", "LocationLongitude" },
                values: new object[] { "Too many tourists at Big Ben", "Big Ben has been overrun by tourists!", new DateTime(2020, 1, 1, 12, 0, 0), 51.500930, -0.124668 }
            );

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "Title", "Description", "Occurrence", "LocationLatitude", "LocationLongitude" },
                values: new object[] { "Sheep at London Bridge", "London Bridge is full of pesky sheep!", new DateTime(2020, 2, 1, 12, 0, 0), 51.508065, -0.087728 }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Incidents]");
            migrationBuilder.Sql("DELETE FROM [Locations]");
        }
    }
}
