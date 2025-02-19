using Medical.Domain.Dto.Brand;

namespace Medical.App.Services.BrandService;

public interface IBrandService
{
    event Action OnChange;
    List<BrandDto> Brands { get; set; }
    List<BrandDto> AdminBrands { get; set; }
    Task GetBrands();
    Task<BrandDto?> GetBrandByName(string name);
    Task GetAdminBrands();
    Task AddBrand(BrandDto item);
    Task UpdateBrand(BrandDto item);
    Task DeleteBrand(int itemId);
    BrandDto CreateNewBrand();
}
