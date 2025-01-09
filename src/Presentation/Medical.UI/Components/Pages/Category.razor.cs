using BootstrapBlazor.Components;
using Medical.Domain.Dto.Category;
using Medical.UI.Services.CategoryService;
using Microsoft.AspNetCore.Components;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace Medical.UI.Components.Pages
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Category : ComponentBase
    {
        private static IEnumerable<int> PageItemsSource => [20, 40];

        [Inject]
        private ICategoryService? _categoryService { get; set; }

        [NotNull]
        private List<CategoryDto>? Items { get; set; }

        private static readonly ConcurrentDictionary<Type, Func<IEnumerable<CategoryDto>, string, SortOrder, IEnumerable<CategoryDto>>> SortLambdaCache = new();

        public async Task<QueryData<CategoryDto>> OnQueryAsync(QueryPageOptions options)
        {
            // The code here is not available in actual combat. It is written only for demonstration to prevent all data from being deleted.
            if (Items == null || Items.Any())
            {
                await _categoryService!.GetCategories();
                Items = _categoryService.Categories;
            }

            var items = Items.AsEnumerable();
            var isSearched = false;
            // Handling advanced queries
            if (options.SearchModel is CategoryDto model)
            {
                if (!string.IsNullOrEmpty(model.Name))
                {
                    items = items.Where(item => item.Name?.Contains(model.Name, StringComparison.OrdinalIgnoreCase) ?? false);
                }

                if (!string.IsNullOrEmpty(model.Url))
                {
                    items = items.Where(item => item.Url?.Contains(model.Url, StringComparison.OrdinalIgnoreCase) ?? false);
                }

                isSearched = !string.IsNullOrEmpty(model.Name) || !string.IsNullOrEmpty(model.Url);
            }

            if (options.Searches.Any())
            {
                // Fuzzy search for SearchText
                items = items.Where(options.Searches.GetFilterFunc<CategoryDto>(FilterLogic.Or));
            }

            // Filter
            var isFiltered = false;
            if (options.Filters.Any())
            {
                items = items.Where(options.Filters.GetFilterFunc<CategoryDto>());
                isFiltered = true;
            }

            // Sorting
            var isSorted = false;
            if (!string.IsNullOrEmpty(options.SortName))
            {
                // No sorting is done externally, but sorting is done automatically internally
                var invoker = SortLambdaCache.GetOrAdd(typeof(CategoryDto), key => LambdaExtensions.GetSortLambda<CategoryDto>().Compile());
                items = invoker(items, options.SortName, options.SortOrder);
                isSorted = true;
            }

            var total = items.Count();

            return new QueryData<CategoryDto>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems),
                TotalCount = total,
                IsFiltered = isFiltered,
                IsSorted = isSorted,
                IsSearch = isSearched
            };
        }

        public async Task<bool> SaveAsync(CategoryDto model, ItemChangedType changedType)
        {
            var ret = false;

            if (changedType == ItemChangedType.Add)
            {
                var item = new CategoryDto()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Url = model.Url,
                    IsActive = model.IsActive,
                    Editing = model.Editing,
                    IsNew = model.IsNew
                };
                await _categoryService!.AddCategory(item);
                Items.Add(item);
            }
            else
            {
                var item = Items.OfType<CategoryDto>().FirstOrDefault(o => o.Id == model.Id);
                if (item != null)
                {
                    item.Name = model.Name;
                    item.Url = model.Url;
                    item.IsActive = model.IsActive;
                    item.Editing = model.Editing;
                    item.IsNew = model.IsNew;
                }
                await _categoryService!.UpdateCategory(item!);
            }
            ret = true;

            return ret;
        }

        public async Task<bool> DeleteAsync(IEnumerable<CategoryDto> models)
        {
            var ret = false;
            foreach (var model in models)
            {
                await _categoryService!.DeleteCategory(model.Id);
                Items.Remove(model);
            }
            ret = true;

            return ret;
        }

    }
}
