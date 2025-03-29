using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Persistence.Configuration;
public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasData(
            new Brand { Id = 1, Name = "AVANTARI", BusinessName = "AVANTARI S.A.C.", RucCode = "20510663919" },
            new Brand { Id = 2, Name = "BIO AURORA", BusinessName = "BIO-AURORA E.I.R.L.", RucCode = "20537575701" },
            new Brand { Id = 3, Name = "BIO NATURISTA", BusinessName = "LABORATORIO ALGAS MARINAS S.A.C.", RucCode = "20265195602" },
            new Brand { Id = 4, Name = "BRANSON SPORT", BusinessName = "BRANSON SPORT LINE S.A.C.", RucCode = "20518184076" },
            new Brand { Id = 5, Name = "CAMPOS SALUD", BusinessName = "CAMPOS SALUD", RucCode = "" },
            new Brand { Id = 6, Name = "CORONEL", BusinessName = "CORONEL IMPORT S.A.C.", RucCode = "20604962952" },
            new Brand { Id = 7, Name = "CYNOMAX", BusinessName = "CYNOMAX S.A.C.", RucCode = "20601399807" },
            new Brand { Id = 8, Name = "ECO VALLE", BusinessName = "ECOVALLE S.A.C.", RucCode = "20551549705" },
            new Brand { Id = 9, Name = "ESCOLLANOS", BusinessName = "ESCOLLANOS S.R.L.", RucCode = "20605650598" },
            new Brand { Id = 10, Name = "FIRSTMED PHARMA", BusinessName = "FIRSTMED PHARMA PERU S.A.C.", RucCode = "20552906366" },
            new Brand { Id = 11, Name = "HUAROCHIRI", BusinessName = "HUAROCHIRI", RucCode = "" },
            new Brand { Id = 12, Name = "JUST", BusinessName = "SWISSJUST LATINOAMERICA S.A. SUCURSAL PERU", RucCode = "20512047352" },
            new Brand { Id = 13, Name = "KETOLIFE", BusinessName = "KETOLIFE", RucCode = "" },
            new Brand { Id = 14, Name = "LA ASOCIACION", BusinessName = "LA ASOCIACION", RucCode = "" },
            new Brand { Id = 15, Name = "LABORATORIO DEL FARMA S.A.C", BusinessName = "LABORATORIOS DELFARMA S.A.C.", RucCode = "20505550111" },
            new Brand { Id = 16, Name = "LEEMARK", BusinessName = "LEEMARK E.I.R.L.", RucCode = "20538188116" },
            new Brand { Id = 17, Name = "LIDER PHARMA", BusinessName = "LIDER PHARMA S.A.", RucCode = "20478203676" },
            new Brand { Id = 18, Name = "LINEA COMERCIAL GENERICA", BusinessName = "LINEA COMERCIAL GENERICA", RucCode = "" },
            new Brand { Id = 19, Name = "LOTUS", BusinessName = "LOTUS", RucCode = "" },
            new Brand { Id = 20, Name = "LUZ ALFA", BusinessName = "CORPORACIÓN GEONATUR S.A.C.", RucCode = "20502817362" },
            new Brand { Id = 21, Name = "MASON NATURAL", BusinessName = "CORPORACION ARION S.A.C.", RucCode = "20507410791" },
            new Brand { Id = 22, Name = "MIA", BusinessName = "MIA", RucCode = "" },
            new Brand { Id = 23, Name = "MISHA RASTRERA", BusinessName = "EMPRENDIMIENTOS ECOLOGICOS MISHA RASTRERA S.A.C.", RucCode = "20601560489" },
            new Brand { Id = 24, Name = "NATURAL POWER", BusinessName = "NATURAL POWER", RucCode = "" },
            new Brand { Id = 25, Name = "NUTRICOST", BusinessName = "IMPORTACIONES SUMAK E.I.R.L.", RucCode = "20609942984" },
            new Brand { Id = 26, Name = "OZOSANA", BusinessName = "OZOSANA", RucCode = "" },
            new Brand { Id = 27, Name = "SANTA NATURA", BusinessName = "ANDINA NATURAL Y DISTRIBUCIÓN E.I.R.L.", RucCode = "20602114121" },
            new Brand { Id = 28, Name = "SIMILIA", BusinessName = "SIMILIA", RucCode = "" },
            new Brand { Id = 29, Name = "SIN MARCA", BusinessName = "SIN MARCA", RucCode = "" },
            new Brand { Id = 30, Name = "SUNDOWN", BusinessName = "NATURAL CENTER IMPORT S.A.C.", RucCode = "20605643028" },
            new Brand { Id = 31, Name = "SUNSHINE", BusinessName = "SUNSHINE", RucCode = "" },
            new Brand { Id = 32, Name = "TAKIWASI", BusinessName = "CENTRO DE REHABILITACION DE TOXICOMANOS Y DE INVESTIGACION DE MEDICINAS TRADICIONALES- TAKIWASI", RucCode = "20172245065" },
            new Brand { Id = 33, Name = "THANIWASI", BusinessName = "THANIWASI", RucCode = "" },
            new Brand { Id = 34, Name = "VIDA NATURAL", BusinessName = "VIDA NATURAL S.A.C.", RucCode = "20512769064" },
            new Brand { Id = 35, Name = "VIVIR POWER SNACKS", BusinessName = "VIVIR PERU S.A.C.", RucCode = "20600310861" },
            new Brand { Id = 36, Name = "ABBOTT", BusinessName = "ABBOTT LABORATORIOS S.A.", RucCode = "20100096936" },
            new Brand { Id = 37, Name = "GSK", BusinessName = "GLAXOSMITHKLINE PERU S.A.", RucCode = "20100123682" },
            new Brand { Id = 38, Name = "PORTUGAL", BusinessName = "LABORATORIOS PORTUGAL S.R.L.", RucCode = "20100204330" }
        );
    }
}

