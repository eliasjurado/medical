using Medical.Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Persistence.Configuration;
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasData(
            new Category
            {
                Id = 1,
                Name = "PRODUCTOS NATURALES",
                Code="13",
                TypeArticleId = TypeArticleId.ProductionWithStockControl
            },
            new Category
            {
                Id = 2,
                Name = "AJENOS AL NEGOCIO",
                Code = "14",
                TypeArticleId = TypeArticleId.NonRelatedToBusiness
            },
            new Category
            {
                Id = 3,
                Name = "TERAPIA DE VITAMINAS",
                Code = "12",
                TypeArticleId = TypeArticleId.ProductionWithOutStockControl
            },
            new Category
            {
                Id = 4,
                Name = "MEDICINA CHINA",
                Code = "77",
                TypeArticleId = TypeArticleId.ForSale
            },
            new Category
            {
                Id = 5,
                Name = "INMOBILIZADOR P/B",
                Code = "76",
                TypeArticleId = TypeArticleId.ForSale
            },
            new Category
            {
                Id = 6,
                Name = "MEDICAMENTOS",
                Code = "10",
                TypeArticleId = TypeArticleId.ForSale
            },
            new Category
            {
                Id = 7,
                Name = "INSUMOS",
                Code = "11",
                TypeArticleId = TypeArticleId.Input
            }
        );
    }
}

