using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PsychotherapistApp.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Psychotherapists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psychotherapists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalendarRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    PsychotherapistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarRecords_Psychotherapists_PsychotherapistId",
                        column: x => x.PsychotherapistId,
                        principalTable: "Psychotherapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Psychotherapists",
                columns: new[] { "Id", "Email", "Name", "Surname" },
                values: new object[] { 1, "bob.green@gmail.com", "Bob", "Green" });

            migrationBuilder.InsertData(
                table: "Psychotherapists",
                columns: new[] { "Id", "Email", "Name", "Surname" },
                values: new object[] { 2, "john.smith@gmail.com", "John", " Smith" });

            migrationBuilder.InsertData(
                table: "CalendarRecords",
                columns: new[] { "Id", "Description", "EndTime", "Frequency", "PsychotherapistId", "RoomNumber", "StartTime" },
                values: new object[] { 1, "Description1", new TimeSpan(0, 2, 30, 0, 0), 1, 1, 1, new TimeSpan(0, 2, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "CalendarRecords",
                columns: new[] { "Id", "Description", "EndTime", "Frequency", "PsychotherapistId", "RoomNumber", "StartTime" },
                values: new object[] { 2, "Description2", new TimeSpan(0, 2, 0, 0, 0), 0, 2, 1, new TimeSpan(0, 1, 0, 0, 0) });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarRecords_PsychotherapistId",
                table: "CalendarRecords",
                column: "PsychotherapistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarRecords");

            migrationBuilder.DropTable(
                name: "Psychotherapists");
        }
    }
}
