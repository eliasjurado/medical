using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Medical.Domain.Enums;
using Medical.Resource;

namespace Medical.Persistence.Configuration;
public class SpecialistConfiguration : IEntityTypeConfiguration<Specialist>
{
    public void Configure(EntityTypeBuilder<Specialist> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(u => u.NumDocument).IsUnique();

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasData(
           new Specialist { Id = 1, TypeDocumentId = TypeDocumentId.DNI, NumDocument = Constants.USER_GENERIC_ID, FullName = Constants.USER_GENERIC_NAME, Birthdate = Constants.USER_GENERIC_BIRTHDATE }
           );
    }
}

