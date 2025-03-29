using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Persistence.Configuration;
public class SaleArticleConfiguration : IEntityTypeConfiguration<SaleArticle>
{
    public void Configure(EntityTypeBuilder<SaleArticle> builder)
    {
        builder.HasKey(x => new { x.SaleId, x.Id });

        builder.HasQueryFilter(x => !x.IsDeleted);

    }
}

