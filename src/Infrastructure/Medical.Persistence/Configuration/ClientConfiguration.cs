using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Persistence.Configuration;
public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(u => u.NumDocument).IsUnique();

        builder.HasQueryFilter(x => !x.IsDeleted);

    }
}

