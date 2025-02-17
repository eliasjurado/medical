using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Persistence.Configuration;
public class FiscalSegmentConfiguration : IEntityTypeConfiguration<FiscalSegment>
{
    public void Configure(EntityTypeBuilder<FiscalSegment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasData(
            new FiscalSegment { Id = 1, Code = "41", Name = "41-EQUIPOS Y SUMINISTROS DE LABORATORIO, DE MEDICIÓN, DE OBSERVACIÓN Y DE PRUEBAS" },
            new FiscalSegment { Id = 2, Code = "42", Name = "42-EQUIPO MÉDICO, ACCESORIOS Y SUMINISTROS" },
            new FiscalSegment { Id = 3, Code = "51", Name = "51-MEDICAMENTOS Y PRODUCTOS FARMACÉUTICOS" },
            new FiscalSegment { Id = 4, Code = "85", Name = "85-SERVICIOS DE SALUD" }
            );
    }
}

