using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Persistence.Configuration;
public class FiscalUnitConfiguration : IEntityTypeConfiguration<FiscalUnit>
{
    public void Configure(EntityTypeBuilder<FiscalUnit> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasData(
            new FiscalUnit { Id = 1, Code = "NIU", Name = "UNIDAD" },
            new FiscalUnit { Id = 2, Code = "MMT", Name = "MILIMETRO" },
            new FiscalUnit { Id = 3, Code = "MMK", Name = "MILIMETRO CUADRADO" },
            new FiscalUnit { Id = 4, Code = "MMQ", Name = "MILIMETRO CUBICO" },
            new FiscalUnit { Id = 5, Code = "MIL", Name = "MILLARES" },
            new FiscalUnit { Id = 6, Code = "UM", Name = "MILLON DE UNIDADES" },
            new FiscalUnit { Id = 7, Code = "ONZ", Name = "ONZAS" },
            new FiscalUnit { Id = 8, Code = "PF", Name = "PALETAS" },
            new FiscalUnit { Id = 9, Code = "PK", Name = "PAQUETE" },
            new FiscalUnit { Id = 10, Code = "PR", Name = "PAR" },
            new FiscalUnit { Id = 11, Code = "FOT", Name = "PIES" },
            new FiscalUnit { Id = 12, Code = "FTK", Name = "PIES CUADRADOS" },
            new FiscalUnit { Id = 13, Code = "FTQ", Name = "PIES CUBICOS" },
            new FiscalUnit { Id = 14, Code = "C62", Name = "PIEZAS" },
            new FiscalUnit { Id = 15, Code = "PG", Name = "PLACAS" },
            new FiscalUnit { Id = 16, Code = "ST", Name = "PLIEGO" },
            new FiscalUnit { Id = 17, Code = "INH", Name = "PULGADAS" },
            new FiscalUnit { Id = 18, Code = "RM", Name = "RESMA" },
            new FiscalUnit { Id = 19, Code = "DR", Name = "TAMBOR" },
            new FiscalUnit { Id = 20, Code = "STN", Name = "TONELADA CORTA" },
            new FiscalUnit { Id = 21, Code = "LTN", Name = "TONELADA LARGA" },
            new FiscalUnit { Id = 22, Code = "TNE", Name = "TONELADAS" },
            new FiscalUnit { Id = 23, Code = "TU", Name = "TUBOS" },
            new FiscalUnit { Id = 24, Code = "ZZ", Name = "UNIDAD (SERVICIOS)" },
            new FiscalUnit { Id = 25, Code = "GLL", Name = "US GALON (3,78L)" },
            new FiscalUnit { Id = 26, Code = "YRD", Name = "YARDA" },
            new FiscalUnit { Id = 27, Code = "YDK", Name = "YARDA CUADRADA" },
            new FiscalUnit { Id = 28, Code = "MLT", Name = "MILILITRO" },
            new FiscalUnit { Id = 29, Code = "MGM", Name = "MILIGRAMOS" },
            new FiscalUnit { Id = 30, Code = "MTQ", Name = "METRO CUBICO" },
            new FiscalUnit { Id = 31, Code = "MTK", Name = "METRO CUADRADO" },
            new FiscalUnit { Id = 32, Code = "MTR", Name = "METRO" },
            new FiscalUnit { Id = 33, Code = "4A", Name = "BOBINAS" },
            new FiscalUnit { Id = 34, Code = "BJ", Name = "BALDE" },
            new FiscalUnit { Id = 35, Code = "BLL", Name = "BARRILES" },
            new FiscalUnit { Id = 36, Code = "BG", Name = "BOLSA" },
            new FiscalUnit { Id = 37, Code = "BO", Name = "BOTELLAS" },
            new FiscalUnit { Id = 38, Code = "BX", Name = "CAJA" },
            new FiscalUnit { Id = 39, Code = "CT", Name = "CARTONES" },
            new FiscalUnit { Id = 40, Code = "CMK", Name = "CENTIMETRO CUADRADO" },
            new FiscalUnit { Id = 41, Code = "CMQ", Name = "CENTIMETRO CUBICO" },
            new FiscalUnit { Id = 42, Code = "CMT", Name = "CENTIMETRO LINEAL" },
            new FiscalUnit { Id = 43, Code = "CEN", Name = "CIENTO DE UNIDADES" },
            new FiscalUnit { Id = 44, Code = "CY", Name = "CILINDRO" },
            new FiscalUnit { Id = 45, Code = "CJ", Name = "CONOS" },
            new FiscalUnit { Id = 46, Code = "DZN", Name = "DOCENA" },
            new FiscalUnit { Id = 47, Code = "DZP", Name = "DOCENA POR 10**6" },
            new FiscalUnit { Id = 48, Code = "BE", Name = "FARDO" },
            new FiscalUnit { Id = 49, Code = "GLI", Name = "GALON INGLES (4,54L)" },
            new FiscalUnit { Id = 50, Code = "GRM", Name = "GRAMO" },
            new FiscalUnit { Id = 51, Code = "GRO", Name = "GRUESA" },
            new FiscalUnit { Id = 52, Code = "HLT", Name = "HECTOLITRO" },
            new FiscalUnit { Id = 53, Code = "LEF", Name = "HOJA" },
            new FiscalUnit { Id = 54, Code = "KGM", Name = "KILOGRAMO" },
            new FiscalUnit { Id = 55, Code = "KTM", Name = "KILOMETRO" },
            new FiscalUnit { Id = 56, Code = "KWM", Name = "KILOVATIO HORA" },
            new FiscalUnit { Id = 57, Code = "KT", Name = "kit" },
            new FiscalUnit { Id = 58, Code = "CA", Name = "LATAS" },
            new FiscalUnit { Id = 59, Code = "LBR", Name = "LIBRAS" },
            new FiscalUnit { Id = 60, Code = "LTR", Name = "LITRO" },
            new FiscalUnit { Id = 61, Code = "MWH", Name = "MEGAWATT HORA" }
            );
    }
}

