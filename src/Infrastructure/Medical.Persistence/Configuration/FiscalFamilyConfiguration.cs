using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Persistence.Configuration;
public class FiscalFamilyConfiguration : IEntityTypeConfiguration<FiscalFamily>
{
    public void Configure(EntityTypeBuilder<FiscalFamily> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasData(
            new FiscalFamily { Id = 1, Code = "4110", SegmentCode = "41", Name = "4110-EQUIPO DE LABORATORIO Y CIENTÍFICO" },
            new FiscalFamily { Id = 2, Code = "4111", SegmentCode = "41", Name = "4111-INSTRUMENTOS DE MEDIDA, OBSERVACIÓN Y ENSAYO" },
            new FiscalFamily { Id = 3, Code = "4112", SegmentCode = "41", Name = "4112-SUMINISTROS Y ACCESORIOS DE LABORATORIO" },
            new FiscalFamily { Id = 4, Code = "4212", SegmentCode = "42", Name = "4212-EQUIPOS Y SUMINISTROS VETERINARIOS" },
            new FiscalFamily { Id = 5, Code = "4213", SegmentCode = "42", Name = "4213-TELAS Y VESTIDOS MÉDICOS" },
            new FiscalFamily { Id = 6, Code = "4214", SegmentCode = "42", Name = "4214-SUMINISTROS, PRODUCTOS DE TRATAMIENTO Y CUIDADO DEL ENFERMO" },
            new FiscalFamily { Id = 7, Code = "4215", SegmentCode = "42", Name = "4215-EQUIPOS Y SUMINISTROS DENTALES" },
            new FiscalFamily { Id = 8, Code = "4216", SegmentCode = "42", Name = "4216-EQUIPO DE DIÁLISIS Y SUMINISTROS" },
            new FiscalFamily { Id = 9, Code = "4217", SegmentCode = "42", Name = "4217-PRODUCTOS PARA LOS SERVICIOS MÉDICOS DE URGENCIAS Y CAMPO" },
            new FiscalFamily { Id = 10, Code = "4218", SegmentCode = "42", Name = "4218-PRODUCTOS DE EXAMEN Y CONTROL DEL PACIENTE" },
            new FiscalFamily { Id = 11, Code = "4219", SegmentCode = "42", Name = "4219-PRODUCTOS DE CENTRO MÉDICO" },
            new FiscalFamily { Id = 12, Code = "4220", SegmentCode = "42", Name = "4220-PRODUCTOS DE HACER IMÁGENES DIAGNÓSTICAS MÉDICAS Y DE MEDICINA NUCLEAR" },
            new FiscalFamily { Id = 13, Code = "4221", SegmentCode = "42", Name = "4221-AYUDA PARA PERSONAS CON DESAFÍOS FÍSICOS PARA VIVIR INDEPENDIENTE" },
            new FiscalFamily { Id = 14, Code = "4222", SegmentCode = "42", Name = "4222-PRODUCTOS PARA ADMINISTRACIÓN INTRAVENOSA Y ARTERIAL" },
            new FiscalFamily { Id = 15, Code = "4223", SegmentCode = "42", Name = "4223-NUTRICIÓN CLÍNICA" },
            new FiscalFamily { Id = 16, Code = "4224", SegmentCode = "42", Name = "4224-PRODUCTOS MEDICINALES DE DEPORTES Y ORTOPÉDICOS Y PRÓTESIS" },
            new FiscalFamily { Id = 17, Code = "4225", SegmentCode = "42", Name = "4225-PRODUCTOS DE REHABILITACIÓN Y TERAPIA OCUPACIONAL Y FÍSICA" },
            new FiscalFamily { Id = 18, Code = "4226", SegmentCode = "42", Name = "4226-EQUIPO Y SUMINISTROS POST MORTEM Y FUNERARIOS" },
            new FiscalFamily { Id = 19, Code = "4227", SegmentCode = "42", Name = "4227-PRODUCTOS DE RESUCITACIÓN, ANESTESIA Y RESPIRATORIO" },
            new FiscalFamily { Id = 20, Code = "4228", SegmentCode = "42", Name = "4228-PRODUCTOS PARA LA ESTERILIZACIÓN MÉDICA" },
            new FiscalFamily { Id = 21, Code = "4229", SegmentCode = "42", Name = "4229-PRODUCTOS QUIRÚRGICOS" },
            new FiscalFamily { Id = 22, Code = "4230", SegmentCode = "42", Name = "4230-SUMINISTROS PARA FORMACIÓN Y ESTUDIOS DE MEDICINA" },
            new FiscalFamily { Id = 23, Code = "4231", SegmentCode = "42", Name = "4231-PRODUCTOS PARA EL CUIDADO DE HERIDAS" },
            new FiscalFamily { Id = 24, Code = "4232", SegmentCode = "42", Name = "4232-IMPLANTES ORTOPÉDICOS QUIRÚRGICOS" },
            new FiscalFamily { Id = 25, Code = "5110", SegmentCode = "51", Name = "5110-MEDICAMENTOS ANTIINFECCIOSOS" },
            new FiscalFamily { Id = 26, Code = "5111", SegmentCode = "51", Name = "5111-AGENTES ANTITUMORALES" },
            new FiscalFamily { Id = 27, Code = "5112", SegmentCode = "51", Name = "5112-MEDICAMENTOS CARDIOVASCULARES" },
            new FiscalFamily { Id = 28, Code = "5113", SegmentCode = "51", Name = "5113-MEDICAMENTOS HEMATÓLOGOS" },
            new FiscalFamily { Id = 29, Code = "5114", SegmentCode = "51", Name = "5114-MEDICAMENTOS PARA EL SISTEMA NERVIOSO CENTRAL" },
            new FiscalFamily { Id = 30, Code = "5115", SegmentCode = "51", Name = "5115-MEDICAMENTOS PARA EL SISTEMA NERVIOSO AUTÓNOMO" },
            new FiscalFamily { Id = 31, Code = "5116", SegmentCode = "51", Name = "5116-MEDICAMENTOS QUE AFECTAN AL SISTEMA RESPIRATORIO" },
            new FiscalFamily { Id = 32, Code = "5117", SegmentCode = "51", Name = "5117-MEDICAMENTOS QUE AFECTAN AL SISTEMA GASTROINTESTINAL" },
            new FiscalFamily { Id = 33, Code = "5118", SegmentCode = "51", Name = "5118-HORMONAS Y ANTAGONISTAS HORMONALES" },
            new FiscalFamily { Id = 34, Code = "5119", SegmentCode = "51", Name = "5119-AGENTES QUE AFECTAN EL AGUA Y LOS ELECTROLITOS" },
            new FiscalFamily { Id = 35, Code = "5120", SegmentCode = "51", Name = "5120-MEDICAMENTOS INMUNOMODULADORES" },
            new FiscalFamily { Id = 36, Code = "5121", SegmentCode = "51", Name = "5121-CATEGORÍAS DE MEDICAMENTOS VARIOS" },
            new FiscalFamily { Id = 37, Code = "5124", SegmentCode = "51", Name = "5124-FÁRMACOS QUE AFECTAN A LOS OÍDOS, LOS OJOS, LA NARIZ Y LA PIEL" },
            new FiscalFamily { Id = 38, Code = "5125", SegmentCode = "51", Name = "5125-SUPLEMENTOS ALIMENTICIOS VETERINARIOS" },
            new FiscalFamily { Id = 39, Code = "8510", SegmentCode = "85", Name = "8510-SERVICIOS INTEGRALES DE SALUD" },
            new FiscalFamily { Id = 40, Code = "8511", SegmentCode = "85", Name = "8511-PREVENCIÓN Y CONTROL DE ENFERMEDADES" },
            new FiscalFamily { Id = 41, Code = "8512", SegmentCode = "85", Name = "8512-PRÁCTICA MÉDICA" },
            new FiscalFamily { Id = 42, Code = "8513", SegmentCode = "85", Name = "8513-CIENCIA MÉDICA, INVESTIGACIÓN Y EXPERIMENTACIÓN" },
            new FiscalFamily { Id = 43, Code = "8514", SegmentCode = "85", Name = "8514-MEDICINA ALTERNATIVA Y HOLÍSTICA" },
            new FiscalFamily { Id = 44, Code = "8515", SegmentCode = "85", Name = "8515-SERVICIOS ALIMENTICIOS Y DE NUTRICIÓN" },
            new FiscalFamily { Id = 45, Code = "8516", SegmentCode = "85", Name = "8516-SERVICIOS DE MANTENIMIENTO, RENOVACIÓN Y REPARACIÓN DE EQUIPO MÉDICO QUIRÚRGICO" },
            new FiscalFamily { Id = 46, Code = "8517", SegmentCode = "85", Name = "8517-SERVICIOS DE MUERTE Y SOPORTE AL FALLECIMIENTO" }
            );
    }
}

