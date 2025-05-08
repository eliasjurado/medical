using Medical.Domain.Enums;
using Medical.Resource;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Persistence.Configuration;
public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(u => u.NumDocument).IsUnique();

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasData(
           new Client { Id = 1, TypeDocumentId = TypeDocumentId.DNI, NumDocument = Constants.USER_GENERIC_ID, FullName = Constants.USER_GENERIC_NAME, Birthdate = Constants.USER_GENERIC_BIRTHDATE }
           );
    }
}

