using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Persistence.Configuration;
public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasData(
            new Brand { Id = 1, Name = "AVANTARI" },
            new Brand { Id = 2, Name = "BIO AURORA" },
            new Brand { Id = 3, Name = "BIO NATURISTA" },
            new Brand { Id = 4, Name = "BRANSON SPORT" },
            new Brand { Id = 5, Name = "CAMPOS SALUD" },
            new Brand { Id = 6, Name = "CORONEL" },
            new Brand { Id = 7, Name = "CYNOMAX S.A.C" },
            new Brand { Id = 8, Name = "ECO VALLE" },
            new Brand { Id = 9, Name = "ESCOLLANOS" },
            new Brand { Id = 10, Name = "FIRSTMED PHARMA" },
            new Brand { Id = 11, Name = "HUAROCHIRI" },
            new Brand { Id = 12, Name = "JUST" },
            new Brand { Id = 13, Name = "KETOLIFE" },
            new Brand { Id = 14, Name = "LA ASOCIACION" },
            new Brand { Id = 15, Name = "LABORATORIO DEL FARMA S.A.C" },
            new Brand { Id = 16, Name = "LEEMARK" },
            new Brand { Id = 17, Name = "LIDER PHARMA" },
            new Brand { Id = 18, Name = "LINEA COMERCIAL GENERICA" },
            new Brand { Id = 19, Name = "LOTUS" },
            new Brand { Id = 20, Name = "LUZ ALFA" },
            new Brand { Id = 21, Name = "MASON NATURAL" },
            new Brand { Id = 22, Name = "MIA" },
            new Brand { Id = 23, Name = "MISHA RASTRERA" },
            new Brand { Id = 24, Name = "NATURAL POWER" },
            new Brand { Id = 25, Name = "NUTRICOST" },
            new Brand { Id = 26, Name = "OZOSANA" },
            new Brand { Id = 27, Name = "SANTA NATURA" },
            new Brand { Id = 28, Name = "SIMILIA" },
            new Brand { Id = 29, Name = "SIN MARCA" },
            new Brand { Id = 30, Name = "SUNDOWN" },
            new Brand { Id = 31, Name = "SUNSHINE" },
            new Brand { Id = 32, Name = "TAKIWASI" },
            new Brand { Id = 33, Name = "THANIWASI" },
            new Brand { Id = 34, Name = "VIDA NATURAL" },
            new Brand { Id = 35, Name = "VIVIR POWER SNACKS" },
            new Brand { Id = 36, Name = "ABBOTT" }
        );
    }
}

