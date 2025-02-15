using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

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
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9403) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9411) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9412) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9413) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9414) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9415) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9416) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9417) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9418) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9419) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9420) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9421) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9422) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9423) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9424) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9425) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9425) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9426) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9427) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9428) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9429) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9430) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9484) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9488) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9489) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9490) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9491) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9492) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9493) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9494) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9495) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9496) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9497) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9498) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9499) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9500) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9502) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9503) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9504) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9504) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 1m, new DateTime(2025, 2, 15, 21, 40, 11, 500, DateTimeKind.Utc).AddTicks(9505) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(2564));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(2575));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7379) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7390) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7392) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7394) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7396) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7398) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7402) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7404) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7405) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7407) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7408) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7410) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7411) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7413) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7414) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7415) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7417) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7418) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7419) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7421) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7422) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7423) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7424) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7426) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7427) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7428) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7430) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7431) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7432) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7433) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7502) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7504) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7505) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7507) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7508) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7509) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7511) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7513) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7515) });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Cost", "CreatedUtc" },
                values: new object[] { 0m, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7516) });
        }
    }
}
