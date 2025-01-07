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

