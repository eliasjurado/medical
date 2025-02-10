using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Persistence.Configuration;
public class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
{
    public void Configure(EntityTypeBuilder<Treatment> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasData(
            new Treatment { Id = 1, Name = "Ácido Hialurónico"},
            new Treatment { Id = 2, Name = "Acupuntura"},
            new Treatment { Id = 3, Name = "Autohemoterapia Mayor"},
            new Treatment { Id = 4, Name = "Autohemoterapia Menor"},
            new Treatment { Id = 5, Name = "Biodescodificación"},
            new Treatment { Id = 6, Name = "Biomagnetismo"},
            new Treatment { Id = 7, Name = "Botox"},
            new Treatment { Id = 8, Name = "Consulta De Fitomedicina"},
            new Treatment { Id = 9, Name = "Consulta Estética"},
            new Treatment { Id = 10, Name = "Consulta Homeopática"},
            new Treatment { Id = 11, Name = "Consulta Traumatología"},
            new Treatment { Id = 12, Name = "Consulta Via Online"},
            new Treatment { Id = 13, Name = "Control De Continuador"},
            new Treatment { Id = 14, Name = "Control Prenatal"},
            new Treatment { Id = 15, Name = "Digitupuntura"},
            new Treatment { Id = 16, Name = "Drenaje Linfático"},
            new Treatment { Id = 17, Name = "Ecografía"},
            new Treatment { Id = 18, Name = "Electroestimulación Muscular"},
            new Treatment { Id = 19, Name = "Gineco-Obstetricia"},
            new Treatment { Id = 20, Name = "Hilos Tensores"},
            new Treatment { Id = 21, Name = "Laboratorio Clínico"},
            new Treatment { Id = 22, Name = "Lavado Y Ozonoterapia Vaginal"},
            new Treatment { Id = 23, Name = "Limpieza Facial Profunda"},
            new Treatment { Id = 24, Name = "Lipotransferencia"},
            new Treatment { Id = 25, Name = "Magnetoterapia"},
            new Treatment { Id = 26, Name = "Masaje Descontracturante"},
            new Treatment { Id = 27, Name = "Masaje Reductor"},
            new Treatment { Id = 28, Name = "Masaje Relajante"},
            new Treatment { Id = 29, Name = "Ozonoterapia Rectal"},
            new Treatment { Id = 30, Name = "Papanicolau"},
            new Treatment { Id = 31, Name = "Peeling Químico"},
            new Treatment { Id = 32, Name = "Peptonas"},
            new Treatment { Id = 33, Name = "Plasma Rico En Plaquetas"},
            new Treatment { Id = 34, Name = "Podología"},
            new Treatment { Id = 35, Name = "Quiropraxia"},
            new Treatment { Id = 36, Name = "Radiofrecuencia"},
            new Treatment { Id = 37, Name = "Suero Ozonizado"},
            new Treatment { Id = 38, Name = "Terapia De Vitaminas"},
            new Treatment { Id = 39, Name = "Terapia Física Y Rehabilitación"},
            new Treatment { Id = 40, Name = "Terapia Neural"},
            new Treatment { Id = 41, Name = "Ultrasonido"}
            );
    }
}

