using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Persistence.Configuration;
public class PacientConfiguration : IEntityTypeConfiguration<Pacient>
{
    public void Configure(EntityTypeBuilder<Pacient> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(u => u.NumDocument).IsUnique();

        builder.HasQueryFilter(x => !x.IsDeleted);

    }
}

