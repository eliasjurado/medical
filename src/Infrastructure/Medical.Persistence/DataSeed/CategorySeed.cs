using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical.Persistence.DataSeed;
public class CategorySeed : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasData(
            new Category
            {
                Id = 1,
                Name = "Bienes",
                Url = "bienes"
            },
            new Category
            {
                Id = 2,
                Name = "Servicios",
                Url = "servicios"
            }
            );
    }
}

