using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Medical.Domain.Enums;
using Medical.Resource;

namespace Medical.Persistence.Configuration;
public class PacientConfiguration : IEntityTypeConfiguration<Pacient>
{
    public void Configure(EntityTypeBuilder<Pacient> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(u => u.NumDocument).IsUnique();

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasData(
           new Pacient { Id = 1, TypeDocumentId = TypeDocumentId.DNI, NumDocument = Constants.USER_GENERIC_ID, FullName = Constants.USER_GENERIC_NAME, Birthdate = Constants.USER_GENERIC_BIRTHDATE }
           );
    }
}

