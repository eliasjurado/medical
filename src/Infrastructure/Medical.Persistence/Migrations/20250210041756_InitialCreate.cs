using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Medical.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeDocumentId = table.Column<int>(type: "int", nullable: false),
                    NumDocument = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeSexId = table.Column<int>(type: "int", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeDocumentId = table.Column<int>(type: "int", nullable: false),
                    NumDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialtyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RneCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeSexId = table.Column<int>(type: "int", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "TypeAppointment",
                columns: table => new
                {
                    TypeAppointmentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAppointment", x => x.TypeAppointmentId);
                });

            migrationBuilder.CreateTable(
                name: "TypeDocument",
                columns: table => new
                {
                    TypeDocumentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDocument", x => x.TypeDocumentId);
                });

            migrationBuilder.CreateTable(
                name: "TypeSex",
                columns: table => new
                {
                    TypeSexId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeSex", x => x.TypeSexId);
                });

            migrationBuilder.CreateTable(
                name: "TypeShift",
                columns: table => new
                {
                    TypeShiftId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeShift", x => x.TypeShiftId);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPacient = table.Column<int>(type: "int", nullable: false),
                    IdTreatment = table.Column<int>(type: "int", nullable: false),
                    IdSpecialist = table.Column<int>(type: "int", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeShiftId = table.Column<int>(type: "int", nullable: false),
                    TypeAppointmentId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Pacients_IdPacient",
                        column: x => x.IdPacient,
                        principalTable: "Pacients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Specialists_IdSpecialist",
                        column: x => x.IdSpecialist,
                        principalTable: "Specialists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Treatments_IdTreatment",
                        column: x => x.IdTreatment,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedUtc", "IsActive", "IsDeleted", "LastModifiedBy", "LastModifiedUtc", "Name", "Url" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(2564), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bienes", "bienes" },
                    { 2, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(2575), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Servicios", "servicios" }
                });

            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "Id", "Cost", "CreatedBy", "CreatedUtc", "DurationMinutes", "IsActive", "IsDeleted", "LastModifiedBy", "LastModifiedUtc", "Name" },
                values: new object[,]
                {
                    { 1, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7379), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ácido Hialurónico" },
                    { 2, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7390), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acupuntura" },
                    { 3, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7392), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autohemoterapia Mayor" },
                    { 4, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7394), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autohemoterapia Menor" },
                    { 5, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7396), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Biodescodificación" },
                    { 6, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7398), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Biomagnetismo" },
                    { 7, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7402), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Botox" },
                    { 8, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7404), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consulta De Fitomedicina" },
                    { 9, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7405), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consulta Estética" },
                    { 10, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7407), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consulta Homeopática" },
                    { 11, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7408), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consulta Traumatología" },
                    { 12, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7410), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consulta Via Online" },
                    { 13, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7411), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Control De Continuador" },
                    { 14, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7413), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Control Prenatal" },
                    { 15, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7414), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Digitupuntura" },
                    { 16, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7415), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drenaje Linfático" },
                    { 17, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7417), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ecografía" },
                    { 18, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7418), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electroestimulación Muscular" },
                    { 19, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7419), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gineco-Obstetricia" },
                    { 20, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7421), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hilos Tensores" },
                    { 21, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7422), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laboratorio Clínico" },
                    { 22, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7423), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lavado Y Ozonoterapia Vaginal" },
                    { 23, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7424), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Limpieza Facial Profunda" },
                    { 24, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7426), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lipotransferencia" },
                    { 25, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7427), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Magnetoterapia" },
                    { 26, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7428), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masaje Descontracturante" },
                    { 27, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7430), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masaje Reductor" },
                    { 28, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7431), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masaje Relajante" },
                    { 29, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7432), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ozonoterapia Rectal" },
                    { 30, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7433), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Papanicolau" },
                    { 31, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7502), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peeling Químico" },
                    { 32, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7504), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peptonas" },
                    { 33, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7505), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Plasma Rico En Plaquetas" },
                    { 34, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7507), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Podología" },
                    { 35, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7508), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quiropraxia" },
                    { 36, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7509), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radiofrecuencia" },
                    { 37, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7511), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suero Ozonizado" },
                    { 38, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7512), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terapia De Vitaminas" },
                    { 39, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7513), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terapia Física Y Rehabilitación" },
                    { 40, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7515), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terapia Neural" },
                    { 41, 0m, null, new DateTime(2025, 2, 10, 4, 17, 55, 911, DateTimeKind.Utc).AddTicks(7516), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ultrasonido" }
                });

            migrationBuilder.InsertData(
                table: "TypeAppointment",
                columns: new[] { "TypeAppointmentId", "Name" },
                values: new object[,]
                {
                    { 0, "Consult" },
                    { 1, "Control" }
                });

            migrationBuilder.InsertData(
                table: "TypeDocument",
                columns: new[] { "TypeDocumentId", "Name" },
                values: new object[,]
                {
                    { 0, "DNI" },
                    { 1, "CI" },
                    { 2, "CE" },
                    { 3, "Passport" }
                });

            migrationBuilder.InsertData(
                table: "TypeSex",
                columns: new[] { "TypeSexId", "Name" },
                values: new object[,]
                {
                    { 0, "Female" },
                    { 1, "Male" }
                });

            migrationBuilder.InsertData(
                table: "TypeShift",
                columns: new[] { "TypeShiftId", "Name" },
                values: new object[,]
                {
                    { 0, "Morning" },
                    { 1, "Afternoon" },
                    { 2, "Night" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_IdPacient",
                table: "Appointments",
                column: "IdPacient");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_IdSpecialist",
                table: "Appointments",
                column: "IdSpecialist");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_IdTreatment",
                table: "Appointments",
                column: "IdTreatment");

            migrationBuilder.CreateIndex(
                name: "IX_Pacients_NumDocument",
                table: "Pacients",
                column: "NumDocument",
                unique: true,
                filter: "[NumDocument] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TypeAppointment_Name",
                table: "TypeAppointment",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TypeDocument_Name",
                table: "TypeDocument",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TypeSex_Name",
                table: "TypeSex",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TypeShift_Name",
                table: "TypeShift",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "TypeAppointment");

            migrationBuilder.DropTable(
                name: "TypeDocument");

            migrationBuilder.DropTable(
                name: "TypeSex");

            migrationBuilder.DropTable(
                name: "TypeShift");

            migrationBuilder.DropTable(
                name: "Pacients");

            migrationBuilder.DropTable(
                name: "Specialists");

            migrationBuilder.DropTable(
                name: "Treatments");
        }
    }
}
