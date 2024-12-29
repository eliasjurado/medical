using AutoMapper;
using BootstrapBlazor.Components;
using Medical.Domain.Dto.Category;
using Medical.UI.Services.CategoryService;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace Medical.UI.Data
{

    /// <summary>
    /// Data injection service implementation class
    /// </summary>
    public class CategoryDataService<T> : DataServiceBase<T> where T : class, new()
    {
        private static readonly ConcurrentDictionary<Type, Func<IEnumerable<T>, string, SortOrder, IEnumerable<T>>> SortLambdaCache = new();

        [NotNull]
        private List<T>? Items { get; set; }

        private ICategoryService _categoryService { get; set; }

        public CategoryDataService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            Items = [];
        }


        /// <summary>
        /// Query operation method
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public async override Task<QueryData<T>> QueryAsync(QueryPageOptions options)
        {
            // The code here is not available in actual combat. It is written only for demonstration to prevent all data from being deleted.
            if (Items == null || Items.Count == 0)
            {
                await _categoryService.GetCategories();
                var x = _categoryService.Categories;
                var y = JsonConvert.SerializeObject(x);
                var z = JsonConvert.DeserializeObject<List<T>>(y);
                Items = z;
            }

            var items = Items.AsEnumerable();
            var isSearched = false;
            // Handling advanced queries
            if (options.SearchModel is CategoryDto model)
            {
                if (!string.IsNullOrEmpty(model.Name))
                {
                    items = items.Cast<CategoryDto>().Where(item => item.Name?.Contains(model.Name, StringComparison.OrdinalIgnoreCase) ?? false).Cast<T>();
                }

                if (!string.IsNullOrEmpty(model.Url))
                {
                    items = items.Cast<CategoryDto>().Where(item => item.Url?.Contains(model.Url, StringComparison.OrdinalIgnoreCase) ?? false).Cast<T>();
                }

                isSearched = !string.IsNullOrEmpty(model.Name) || !string.IsNullOrEmpty(model.Url);
            }

            if (options.Searches.Count != 0)
            {
                // Fuzzy search for SearchText
                items = items.Where(options.Searches.GetFilterFunc<T>(FilterLogic.Or));
            }

            // Filter
            var isFiltered = false;
            if (options.Filters.Count != 0)
            {
                items = items.Where(options.Filters.GetFilterFunc<T>());
                isFiltered = true;
            }

            // Sorting
            var isSorted = false;
            if (!string.IsNullOrEmpty(options.SortName))
            {
                // No sorting is done externally, but sorting is done automatically internally
                var invoker = SortLambdaCache.GetOrAdd(typeof(CategoryDto), key => LambdaExtensions.GetSortLambda<T>().Compile());
                items = invoker(items, options.SortName, options.SortOrder);
                isSorted = true;
            }

            var total = items.Count();

            return new QueryData<T>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = total,
                IsFiltered = isFiltered,
                IsSorted = isSorted,
                IsSearch = isSearched
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async override Task<bool> SaveAsync(T model, ItemChangedType changedType)
        {
            var ret = false;
            if (model is CategoryDto i)
            {
                if (changedType == ItemChangedType.Add)
                {
                    var item = new CategoryDto()
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Url = i.Url,
                        IsActive = i.IsActive,
                        Editing = i.Editing,
                        IsNew = i.IsNew
                    };
                    await _categoryService.AddCategory(item);
                    Items.Add(item! as T);
                }
                else
                {
                    var o = Items.OfType<CategoryDto>().FirstOrDefault(s => s.Id == i.Id);
                    if (o != null)
                    {
                        o.Name = i.Name;
                        o.Url = i.Url;
                        o.IsActive = i.IsActive;
                        o.Editing = i.Editing;
                        o.IsNew = i.IsNew;
                    }
                    await _categoryService.UpdateCategory(o);
                }
                ret = true;
            }
            return ret;
        }

        public async override Task<bool> DeleteAsync(IEnumerable<T> models)
        {
            foreach (var model in models)
            {
                if (model is CategoryDto i)
                {
                    await _categoryService.DeleteCategory(i.Id);
                }
                Items.Remove(model);
            }

            return await base.DeleteAsync(models);
        }
    }
}
