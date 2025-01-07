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
                    NumDocument = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeSexId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Pacients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeDocumentId = table.Column<int>(type: "int", nullable: false),
                    NumDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialtyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollegeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollegeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeSexId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "TypeAppointment",
                columns: table => new
                {
                    TypeAppointmentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Appointments_TypeAppointment_TypeAppointmentId",
                        column: x => x.TypeAppointmentId,
                        principalTable: "TypeAppointment",
                        principalColumn: "TypeAppointmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedUtc", "IsActive", "IsDeleted", "LastModifiedBy", "LastModifiedUtc", "Name", "Url" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(2936), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bienes", "bienes" },
                    { 2, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(2945), true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Servicios", "servicios" }
                });

            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "Id", "CreatedBy", "CreatedUtc", "DurationMinutes", "IsActive", "IsDeleted", "LastModifiedBy", "LastModifiedUtc", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6652), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ácido Hialurónico" },
                    { 2, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6656), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acupuntura" },
                    { 3, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6657), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autohemoterapia Mayor" },
                    { 4, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6659), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autohemoterapia Menor" },
                    { 5, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6660), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Biodescodificación" },
                    { 6, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6661), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Biomagnetismo" },
                    { 7, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6662), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Botox" },
                    { 8, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6663), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consulta De Fitomedicina" },
                    { 9, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6664), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consulta Estética" },
                    { 10, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6665), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consulta Homeopática" },
                    { 11, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6666), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consulta Traumatología" },
                    { 12, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6667), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consulta Via Online" },
                    { 13, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6668), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Control De Continuador" },
                    { 14, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6669), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Control Prenatal" },
                    { 15, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6670), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Digitupuntura" },
                    { 16, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6671), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drenaje Linfático" },
                    { 17, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6672), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ecografía" },
                    { 18, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6673), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electroestimulación Muscular" },
                    { 19, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6674), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gineco-Obstetricia" },
                    { 20, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6675), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hilos Tensores" },
                    { 21, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6676), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laboratorio Clínico" },
                    { 22, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6677), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lavado Y Ozonoterapia Vaginal" },
                    { 23, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6678), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Limpieza Facial Profunda" },
                    { 24, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6679), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lipotransferencia" },
                    { 25, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6680), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Magnetoterapia" },
                    { 26, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6681), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masaje Descontracturante" },
                    { 27, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6682), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masaje Reductor" },
                    { 28, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6683), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masaje Relajante" },
                    { 29, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6684), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ozonoterapia Rectal" },
                    { 30, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6685), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Papanicolau" },
                    { 31, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6686), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peeling Químico" },
                    { 32, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6687), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peptonas" },
                    { 33, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6688), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Plasma Rico En Plaquetas" },
                    { 34, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6689), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Podología" },
                    { 35, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6690), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quiropraxia" },
                    { 36, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6691), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radiofrecuencia" },
                    { 37, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6692), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suero Ozonizado" },
                    { 38, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6693), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terapia De Vitaminas" },
                    { 39, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6695), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terapia Física Y Rehabilitación" },
                    { 40, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6695), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terapia Neural" },
                    { 41, null, new DateTime(2025, 1, 7, 8, 36, 15, 619, DateTimeKind.Utc).AddTicks(6696), 30, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ultrasonido" }
                });

            migrationBuilder.InsertData(
                table: "TypeAppointment",
                columns: new[] { "TypeAppointmentId", "Name" },
                values: new object[,]
                {
                    { 0, "None" },
                    { 1, "Consulta" },
                    { 2, "Control" }
                });

            migrationBuilder.InsertData(
                table: "TypeDocument",
                columns: new[] { "TypeDocumentId", "Name" },
                values: new object[,]
                {
                    { 0, "None" },
                    { 1, "DNI" },
                    { 2, "CI" },
                    { 3, "CE" },
                    { 4, "Pasaporte" }
                });

            migrationBuilder.InsertData(
                table: "TypeSex",
                columns: new[] { "TypeSexId", "Name" },
                values: new object[,]
                {
                    { 0, "None" },
                    { 1, "Femenino" },
                    { 2, "Masculino" }
                });

            migrationBuilder.InsertData(
                table: "TypeShift",
                columns: new[] { "TypeShiftId", "Name" },
                values: new object[,]
                {
                    { 0, "None" },
                    { 1, "Dia" },
                    { 2, "Tarde" },
                    { 3, "Noche" }
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
                name: "IX_Appointments_TypeAppointmentId",
                table: "Appointments",
                column: "TypeAppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacients_NumDocument",
                table: "Pacients",
                column: "NumDocument",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TypeAppointment_Name",
                table: "TypeAppointment",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TypeDocument_Name",
                table: "TypeDocument",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TypeSex_Name",
                table: "TypeSex",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TypeShift_Name",
                table: "TypeShift",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Categories");

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

            migrationBuilder.DropTable(
                name: "TypeAppointment");
        }
    }
}
