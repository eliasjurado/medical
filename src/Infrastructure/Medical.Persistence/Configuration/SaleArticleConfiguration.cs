using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Persistence.Configuration;
public class SaleArticleConfiguration : IEntityTypeConfiguration<SaleArticle>
{
    public void Configure(EntityTypeBuilder<SaleArticle> builder)
    {
        builder.HasKey(x => new { x.SaleId, x.Id });

        builder.HasOne(p => p.Sale)
            .WithMany(o => o.SaleArticles)
            .HasForeignKey(q => q.SaleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(x => !x.IsDeleted);

    }
}

