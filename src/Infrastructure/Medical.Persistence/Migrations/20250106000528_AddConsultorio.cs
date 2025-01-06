using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Medical.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddConsultorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "Id", "CreatedBy", "CreatedUtc", "DurationMinutes", "IsActive", "IsDeleted", "LastModifiedBy", "LastModifiedUtc", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(1992), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ácido Hialurónico" },
                    { 2, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(1994), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acupuntura" },
                    { 3, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(1995), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autohemoterapia Mayor" },
                    { 4, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(1996), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autohemoterapia Menor" },
                    { 5, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(1997), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Biodescodificación" },
                    { 6, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(1998), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Biomagnetismo" },
                    { 7, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(1999), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Botox" },
                    { 8, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2000), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consulta De Fitomedicina" },
                    { 9, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2000), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consulta Estética" },
                    { 10, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2001), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consulta Homeopática" },
                    { 11, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2002), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consulta Traumatología" },
                    { 12, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2003), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consulta Via Online" },
                    { 13, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2004), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Control De Continuador" },
                    { 14, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2005), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Control Prenatal" },
                    { 15, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2006), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Digitupuntura" },
                    { 16, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2006), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drenaje Linfático" },
                    { 17, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2007), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ecografía" },
                    { 18, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2008), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electroestimulación Muscular" },
                    { 19, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2009), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gineco-Obstetricia" },
                    { 20, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2010), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hilos Tensores" },
                    { 21, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2011), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laboratorio Clínico" },
                    { 22, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2011), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lavado Y Ozonoterapia Vaginal" },
                    { 23, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2012), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Limpieza Facial Profunda" },
                    { 24, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2013), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lipotransferencia" },
                    { 25, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2014), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Magnetoterapia" },
                    { 26, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2014), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masaje Descontracturante" },
                    { 27, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2015), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masaje Reductor" },
                    { 28, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2016), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masaje Relajante" },
                    { 29, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2017), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ozonoterapia Rectal" },
                    { 30, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2018), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Papanicolau" },
                    { 31, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2018), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peeling Químico" },
                    { 32, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2019), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peptonas" },
                    { 33, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2020), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Plasma Rico En Plaquetas" },
                    { 34, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2021), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Podología" },
                    { 35, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2021), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quiropraxia" },
                    { 36, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2022), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radiofrecuencia" },
                    { 37, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2023), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suero Ozonizado" },
                    { 38, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2024), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terapia De Vitaminas" },
                    { 39, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2025), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terapia Física Y Rehabilitación" },
                    { 40, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2025), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terapia Neural" },
                    { 41, null, new DateTime(2025, 1, 6, 0, 5, 27, 684, DateTimeKind.Utc).AddTicks(2026), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ultrasonido" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedUtc",
                value: new DateTime(2024, 12, 30, 1, 36, 0, 339, DateTimeKind.Utc).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedUtc",
                value: new DateTime(2024, 12, 30, 1, 36, 0, 339, DateTimeKind.Utc).AddTicks(7541));
        }
    }
}
