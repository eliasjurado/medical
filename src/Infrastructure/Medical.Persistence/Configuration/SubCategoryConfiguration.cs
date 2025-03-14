using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Persistence.Configuration;
public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasData(
            new SubCategory { Id = 1, Name = "7 SEMILLAS", Code = "100115", CategoryId = 6 },
            new SubCategory { Id = 2, Name = "ACEITE DE NEEM", Code = "100090", CategoryId = 6 },
            new SubCategory { Id = 3, Name = "ACEITE DE OREGANO COMESTIBLE", Code = "100092", CategoryId = 6 },
            new SubCategory { Id = 4, Name = "ACEITE DE OZONO", Code = "100096", CategoryId = 6 },
            new SubCategory { Id = 5, Name = "ACHICORIA + ORTIGA", Code = "100057", CategoryId = 6 },
            new SubCategory { Id = 6, Name = "ACTIVADOR NUTRIGENÓMICO NRF2", Code = "100081", CategoryId = 6 },
            new SubCategory { Id = 7, Name = "ADELGAZANTE EN POLVO", Code = "100129", CategoryId = 6 },
            new SubCategory { Id = 8, Name = "ADRENAL SUPPORT", Code = "100008", CategoryId = 6 },
            new SubCategory { Id = 9, Name = "AGUAJE", Code = "100101", CategoryId = 6 },
            new SubCategory { Id = 10, Name = "AGUAS DE BACH", Code = "100020", CategoryId = 6 },
            new SubCategory { Id = 11, Name = "ALCOHOL HERBAL CON ROMERO", Code = "130002", CategoryId = 1 },
            new SubCategory { Id = 12, Name = "ALFA PROBIÓTICOS", Code = "100033", CategoryId = 6 },
            new SubCategory { Id = 13, Name = "ALFA-VID", Code = "100141", CategoryId = 6 },
            new SubCategory { Id = 14, Name = "AMACHAY", Code = "100022", CategoryId = 6 },
            new SubCategory { Id = 15, Name = "ANSIOLITICO", Code = "130004", CategoryId = 1 },
            new SubCategory { Id = 16, Name = "ANTI AGE DRIP - OR CAP", Code = "100150", CategoryId = 6 },
            new SubCategory { Id = 17, Name = "ANXY-OUT", Code = "100014", CategoryId = 6 },
            new SubCategory { Id = 18, Name = "AP-G FEMME", Code = "100066", CategoryId = 6 },
            new SubCategory { Id = 19, Name = "APIO-ZAN", Code = "100139", CategoryId = 6 },
            new SubCategory { Id = 20, Name = "ARCILLA", Code = "130003", CategoryId = 1 },
            new SubCategory { Id = 21, Name = "ARGININA", Code = "100006", CategoryId = 6 },
            new SubCategory { Id = 22, Name = "ARTEMISA MAX", Code = "100149", CategoryId = 6 },
            new SubCategory { Id = 23, Name = "ART-PLUS", Code = "100140", CategoryId = 6 },
            new SubCategory { Id = 24, Name = "ASHWAGANDHA POWER (En polvo) 100g", Code = "130012", CategoryId = 1 },
            new SubCategory { Id = 25, Name = "BAO JI WAN (HEMORROIDES MUSK OINTMENT)", Code = "770013", CategoryId = 4 },
            new SubCategory { Id = 26, Name = "BERBERINA", Code = "100023", CategoryId = 6 },
            new SubCategory { Id = 27, Name = "BERBERSOMA FORTE", Code = "100026", CategoryId = 6 },
            new SubCategory { Id = 28, Name = "BIOACTIVO SPRILUNA", Code = "100059", CategoryId = 6 },
            new SubCategory { Id = 29, Name = "BIOCUR", Code = "100040", CategoryId = 6 },
            new SubCategory { Id = 30, Name = "BIOGANDA", Code = "100010", CategoryId = 6 },
            new SubCategory { Id = 31, Name = "BLOQUEADOR SOLAR", Code = "100133", CategoryId = 6 },
            new SubCategory { Id = 32, Name = "BOWEL CLEANSER", Code = "100037", CategoryId = 6 },
            new SubCategory { Id = 33, Name = "BRAGUERO HERNIA INGUINAL (T/L)", Code = "760047", CategoryId = 5 },
            new SubCategory { Id = 34, Name = "BRAGUERO HERNIA INGUINAL (TM)", Code = "760046", CategoryId = 5 }
        );
    }
}

