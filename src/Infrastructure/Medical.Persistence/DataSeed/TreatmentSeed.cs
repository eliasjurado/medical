using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Persistence.DataSeed;
public class TreatmentSeed : IEntityTypeConfiguration<Treatment>
{
    public void Configure(EntityTypeBuilder<Treatment> builder)
    {
        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasData(
            new Treatment { Id = 1, Name = "Ácido Hialurónico", DurationMinutes = 30 },
            new Treatment { Id = 2, Name = "Acupuntura", DurationMinutes = 30 },
            new Treatment { Id = 3, Name = "Autohemoterapia Mayor", DurationMinutes = 30 },
            new Treatment { Id = 4, Name = "Autohemoterapia Menor", DurationMinutes = 30 },
            new Treatment { Id = 5, Name = "Biodescodificación", DurationMinutes = 30 },
            new Treatment { Id = 6, Name = "Biomagnetismo", DurationMinutes = 30 },
            new Treatment { Id = 7, Name = "Botox", DurationMinutes = 30 },
            new Treatment { Id = 8, Name = "Consulta De Fitomedicina", DurationMinutes = 30 },
            new Treatment { Id = 9, Name = "Consulta Estética", DurationMinutes = 30 },
            new Treatment { Id = 10, Name = "Consulta Homeopática", DurationMinutes = 30 },
            new Treatment { Id = 11, Name = "Consulta Traumatología", DurationMinutes = 30 },
            new Treatment { Id = 12, Name = "Consulta Via Online", DurationMinutes = 30 },
            new Treatment { Id = 13, Name = "Control De Continuador", DurationMinutes = 30 },
            new Treatment { Id = 14, Name = "Control Prenatal", DurationMinutes = 30 },
            new Treatment { Id = 15, Name = "Digitupuntura", DurationMinutes = 30 },
            new Treatment { Id = 16, Name = "Drenaje Linfático", DurationMinutes = 30 },
            new Treatment { Id = 17, Name = "Ecografía", DurationMinutes = 30 },
            new Treatment { Id = 18, Name = "Electroestimulación Muscular", DurationMinutes = 30 },
            new Treatment { Id = 19, Name = "Gineco-Obstetricia", DurationMinutes = 30 },
            new Treatment { Id = 20, Name = "Hilos Tensores", DurationMinutes = 30 },
            new Treatment { Id = 21, Name = "Laboratorio Clínico", DurationMinutes = 30 },
            new Treatment { Id = 22, Name = "Lavado Y Ozonoterapia Vaginal", DurationMinutes = 30 },
            new Treatment { Id = 23, Name = "Limpieza Facial Profunda", DurationMinutes = 30 },
            new Treatment { Id = 24, Name = "Lipotransferencia", DurationMinutes = 30 },
            new Treatment { Id = 25, Name = "Magnetoterapia", DurationMinutes = 30 },
            new Treatment { Id = 26, Name = "Masaje Descontracturante", DurationMinutes = 30 },
            new Treatment { Id = 27, Name = "Masaje Reductor", DurationMinutes = 30 },
            new Treatment { Id = 28, Name = "Masaje Relajante", DurationMinutes = 30 },
            new Treatment { Id = 29, Name = "Ozonoterapia Rectal", DurationMinutes = 30 },
            new Treatment { Id = 30, Name = "Papanicolau", DurationMinutes = 30 },
            new Treatment { Id = 31, Name = "Peeling Químico", DurationMinutes = 30 },
            new Treatment { Id = 32, Name = "Peptonas", DurationMinutes = 30 },
            new Treatment { Id = 33, Name = "Plasma Rico En Plaquetas", DurationMinutes = 30 },
            new Treatment { Id = 34, Name = "Podología", DurationMinutes = 30 },
            new Treatment { Id = 35, Name = "Quiropraxia", DurationMinutes = 30 },
            new Treatment { Id = 36, Name = "Radiofrecuencia", DurationMinutes = 30 },
            new Treatment { Id = 37, Name = "Suero Ozonizado", DurationMinutes = 30 },
            new Treatment { Id = 38, Name = "Terapia De Vitaminas", DurationMinutes = 30 },
            new Treatment { Id = 39, Name = "Terapia Física Y Rehabilitación", DurationMinutes = 30 },
            new Treatment { Id = 40, Name = "Terapia Neural", DurationMinutes = 30 },
            new Treatment { Id = 41, Name = "Ultrasonido", DurationMinutes = 30 }
            );
    }
}

