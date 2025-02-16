using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Medical.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFiscalUnitRows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(4468));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(4472));

            migrationBuilder.InsertData(
                table: "FiscalUnits",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedUtc", "IsActive", "IsDeleted", "LastModifiedBy", "LastModifiedUtc", "Name" },
                values: new object[,]
                {
                    { 1, "NIU", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5570), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UNIDAD" },
                    { 2, "MMT", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5572), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MILIMETRO" },
                    { 3, "MMK", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5573), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MILIMETRO CUADRADO" },
                    { 4, "MMQ", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5574), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MILIMETRO CUBICO" },
                    { 5, "MIL", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5575), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MILLARES" },
                    { 6, "UM", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5576), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MILLON DE UNIDADES" },
                    { 7, "ONZ", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5577), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ONZAS" },
                    { 8, "PF", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5637), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PALETAS" },
                    { 9, "PK", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5638), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PAQUETE" },
                    { 10, "PR", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5639), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PAR" },
                    { 11, "FOT", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5640), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PIES" },
                    { 12, "FTK", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5640), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PIES CUADRADOS" },
                    { 13, "FTQ", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5641), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PIES CUBICOS" },
                    { 14, "C62", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5642), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PIEZAS" },
                    { 15, "PG", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5643), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLACAS" },
                    { 16, "ST", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5644), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLIEGO" },
                    { 17, "INH", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5645), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PULGADAS" },
                    { 18, "RM", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5645), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RESMA" },
                    { 19, "DR", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5646), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TAMBOR" },
                    { 20, "STN", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5647), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TONELADA CORTA" },
                    { 21, "LTN", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5648), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TONELADA LARGA" },
                    { 22, "TNE", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5649), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TONELADAS" },
                    { 23, "TU", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5650), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TUBOS" },
                    { 24, "ZZ", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5650), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UNIDAD (SERVICIOS)" },
                    { 25, "GLL", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5651), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "US GALON (3,78L)" },
                    { 26, "YRD", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5652), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "YARDA" },
                    { 27, "YDK", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5653), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "YARDA CUADRADA" },
                    { 28, "MLT", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5654), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MILILITRO" },
                    { 29, "MGM", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5654), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MILIGRAMOS" },
                    { 30, "MTQ", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5655), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "METRO CUBICO" },
                    { 31, "MTK", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5656), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "METRO CUADRADO" },
                    { 32, "MTR", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5657), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "METRO" },
                    { 33, "4A", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5658), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BOBINAS" },
                    { 34, "BJ", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5658), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BALDE" },
                    { 35, "BLL", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5659), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BARRILES" },
                    { 36, "BG", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5660), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BOLSA" },
                    { 37, "BO", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5661), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BOTELLAS" },
                    { 38, "BX", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5661), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAJA" },
                    { 39, "CT", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5662), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CARTONES" },
                    { 40, "CMK", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5663), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CENTIMETRO CUADRADO" },
                    { 41, "CMQ", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5664), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CENTIMETRO CUBICO" },
                    { 42, "CMT", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5664), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CENTIMETRO LINEAL" },
                    { 43, "CEN", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5665), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CIENTO DE UNIDADES" },
                    { 44, "CY", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5666), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CILINDRO" },
                    { 45, "CJ", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5667), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CONOS" },
                    { 46, "DZN", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5668), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DOCENA" },
                    { 47, "DZP", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5669), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DOCENA POR 10**6" },
                    { 48, "BE", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5669), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FARDO" },
                    { 49, "GLI", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5670), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GALON INGLES (4,54L)" },
                    { 50, "GRM", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5671), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GRAMO" },
                    { 51, "GRO", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5672), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GRUESA" },
                    { 52, "HLT", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5673), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HECTOLITRO" },
                    { 53, "LEF", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5674), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HOJA" },
                    { 54, "KGM", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5674), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KILOGRAMO" },
                    { 55, "KTM", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5675), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KILOMETRO" },
                    { 56, "KWM", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5676), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KILOVATIO HORA" },
                    { 57, "KT", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5677), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kit" },
                    { 58, "CA", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5677), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LATAS" },
                    { 59, "LBR", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5678), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LIBRAS" },
                    { 60, "LTR", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5679), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LITRO" },
                    { 61, "MWH", null, new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(5680), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MEGAWATT HORA" }
                });

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8329));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8331));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8332));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8333));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8334));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8335));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8336));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8337));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8338));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8338));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8383));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8384));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8385));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8386));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8387));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8387));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8388));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8389));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8391));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8391));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8392));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8393));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8394));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8394));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8395));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8396));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8396));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8397));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8398));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8398));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8399));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8400));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8401));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8401));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8402));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8403));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8404));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8405));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8405));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedUtc",
                value: new DateTime(2025, 2, 16, 16, 32, 18, 525, DateTimeKind.Utc).AddTicks(8406));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "FiscalUnits",
                keyColumn: "Id",
                keyValue: 61);

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
    }
}
