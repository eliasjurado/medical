using Medical.Domain.Dto.Sales;

namespace Medical.App.Services.SubCategoryService
{
    public interface ISubCategoryService
    {
        event Action OnChange;
        List<SubCategoryDto> SubCategories { get; set; }
        List<SubCategoryDto> AdminSubCategories { get; set; }
        Task GetSubCategories();
        Task<SubCategoryDto?> GetSubCategoryByName(string name);
        Task GetAdminSubCategories();
        Task AddSubCategory(SubCategoryDto item);
        Task UpdateSubCategory(SubCategoryDto item);
        Task DeleteSubCategory(int itemId);
        SubCategoryDto CreateNewSubCategory();
    }
}
