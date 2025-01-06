using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddEspecialista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specialists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeDocument = table.Column<int>(type: "int", nullable: false),
                    NumDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialtyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollegeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollegeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeSex = table.Column<int>(type: "int", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialists", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(6275));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(6279));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7517));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7519));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7520));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7521));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7522));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7523));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7525));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7526));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7528));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7529));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7530));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7531));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7532));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7536));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7537));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7541));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7544));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7546));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7548));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7549));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7550));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7550));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7552));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 4, 25, 24, 206, DateTimeKind.Utc).AddTicks(7554));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Specialists");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(783));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(790));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(1992));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(1994));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(1995));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(1996));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(1997));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2003));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2004));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2005));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2006));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2007));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2008));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2011));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2011));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2012));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2013));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2014));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2014));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2015));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2016));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2017));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2018));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2018));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2019));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2020));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2024));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2025));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2025));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedUtc",
                value: new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2026));
        }
    }
}
