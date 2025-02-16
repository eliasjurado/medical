using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFiscalUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FiscalUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalUnits", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(666));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(671));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(3972));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(3973));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(3974));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(3975));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(3976));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(3977));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(3978));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(3979));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(3980));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(3981));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(3981));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(3982));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(3983));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4031));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4032));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4033));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4034));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4035));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4036));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4038));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4039));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4041));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4042));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4043));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4044));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4046));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4047));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4048));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4051));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4052));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4053));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4054));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 14, 30, 875, DateTimeKind.Utc).AddTicks(4055));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FiscalUnits");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(5690));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(5695));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9403));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9411));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9412));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9413));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9414));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9415));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9416));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9417));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9418));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9419));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9420));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9422));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9423));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9424));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9426));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9427));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9428));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9429));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9430));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9484));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9488));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9489));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9491));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9493));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9495));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9496));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9497));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9499));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9500));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9502));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9504));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9504));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9505));
        }
    }
}
