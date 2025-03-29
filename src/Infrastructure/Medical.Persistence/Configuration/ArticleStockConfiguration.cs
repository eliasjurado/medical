using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Persistence.Configuration;
public class ArticleStockConfiguration : IEntityTypeConfiguration<ArticleStock>
{
    public void Configure(EntityTypeBuilder<ArticleStock> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.BarCode);

        builder.HasQueryFilter(x => !x.IsDeleted);

    }
}

