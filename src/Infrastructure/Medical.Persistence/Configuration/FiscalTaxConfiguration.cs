using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Persistence.Configuration;
public class FiscalTaxConfiguration : IEntityTypeConfiguration<FiscalTax>
{
    public void Configure(EntityTypeBuilder<FiscalTax> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(u => u.NumYear).IsUnique();

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasData(
            new FiscalTax { Id = 1, NumYear = 2024, TaxAmount = 0.18m },
            new FiscalTax { Id = 2, NumYear = 2025, TaxAmount = 0.18m },
            new FiscalTax { Id = 3, NumYear = 2026, TaxAmount = 0.18m },
            new FiscalTax { Id = 4, NumYear = 2027, TaxAmount = 0.18m },
            new FiscalTax { Id = 5, NumYear = 2028, TaxAmount = 0.18m },
            new FiscalTax { Id = 6, NumYear = 2029, TaxAmount = 0.18m },
            new FiscalTax { Id = 7, NumYear = 2030, TaxAmount = 0.18m }
            );
    }
}

