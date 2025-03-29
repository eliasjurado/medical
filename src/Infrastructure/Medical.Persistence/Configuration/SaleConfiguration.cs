using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Persistence.Configuration;
public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(u => new { u.Serie, u.Correlative }).IsUnique();

        builder.HasQueryFilter(x => !x.IsDeleted);

    }
}

