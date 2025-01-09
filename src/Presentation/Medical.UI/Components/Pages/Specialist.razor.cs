using BootstrapBlazor.Components;
using Medical.Domain.Dto.Specialist;
using Medical.UI.Services.SpecialistService;
using Microsoft.AspNetCore.Components;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace Medical.UI.Components.Pages
{
    public partial class Specialist : ComponentBase
    {
        private static IEnumerable<int> PageItemsSource => [20, 40];

        [Inject]
        private ISpecialistService? _specialistService { get; set; }

        [NotNull]
        private List<SpecialistDto>? Items { get; set; }

        private static readonly ConcurrentDictionary<Type, Func<IEnumerable<SpecialistDto>, string, SortOrder, IEnumerable<SpecialistDto>>> SortLambdaCache = new();

        public async Task<QueryData<SpecialistDto>> OnQueryAsync(QueryPageOptions options)
        {
            // The code here is not available in actual combat. It is written only for demonstration to prevent all data from being deleted.
            if (Items == null || Items.Count == 0)
            {
                await _specialistService!.GetSpecialists();
                Items = _specialistService.Specialists;
            }

            var items = Items.AsEnumerable();
            var isSearched = false;
            // Handling advanced queries
            if (options.SearchModel is SpecialistDto model)
            {
                if (!string.IsNullOrEmpty(model.NumDocument))
                {
                    items = items.Where(item => item.NumDocument?.Contains(model.NumDocument, StringComparison.OrdinalIgnoreCase) ?? false);
                }

                if (!string.IsNullOrEmpty(model.Name))
                {
                    items = items.Where(item => item.Name?.Contains(model.Name, StringComparison.OrdinalIgnoreCase) ?? false);
                }

                if (!string.IsNullOrEmpty(model.LastName))
                {
                    items = items.Where(item => item.LastName?.Contains(model.LastName, StringComparison.OrdinalIgnoreCase) ?? false);
                }

                if (!string.IsNullOrEmpty(model.SpecialtyName))
                {
                    items = items.Where(item => item.SpecialtyName?.Contains(model.SpecialtyName, StringComparison.OrdinalIgnoreCase) ?? false);
                }

                if (!string.IsNullOrEmpty(model.CollegeName))
                {
                    items = items.Where(item => item.CollegeName?.Contains(model.CollegeName, StringComparison.OrdinalIgnoreCase) ?? false);
                }

                if (!string.IsNullOrEmpty(model.CollegeId))
                {
                    items = items.Where(item => item.CollegeId?.Contains(model.CollegeId, StringComparison.OrdinalIgnoreCase) ?? false);
                }

                if (!string.IsNullOrEmpty(model.Address))
                {
                    items = items.Where(item => item.Address?.Contains(model.Address, StringComparison.OrdinalIgnoreCase) ?? false);
                }

                if (!string.IsNullOrEmpty(model.Phone))
                {
                    items = items.Where(item => item.Phone?.Contains(model.Phone, StringComparison.OrdinalIgnoreCase) ?? false);
                }

                isSearched = !string.IsNullOrEmpty(model.NumDocument) || !string.IsNullOrEmpty(model.Name) || !string.IsNullOrEmpty(model.LastName) || !string.IsNullOrEmpty(model.SpecialtyName) || !string.IsNullOrEmpty(model.CollegeName) || !string.IsNullOrEmpty(model.CollegeId) || !string.IsNullOrEmpty(model.Address) || !string.IsNullOrEmpty(model.Phone);
            }

            if (options.Searches.Count != 0)
            {
                // Fuzzy search for SearchText
                items = items.Where(options.Searches.GetFilterFunc<SpecialistDto>(FilterLogic.Or));
            }

            // Filter
            var isFiltered = false;
            if (options.Filters.Count != 0)
            {
                items = items.Where(options.Filters.GetFilterFunc<SpecialistDto>());
                isFiltered = true;
            }

            // Sorting
            var isSorted = false;
            if (!string.IsNullOrEmpty(options.SortName))
            {
                // No sorting is done externally, but sorting is done automatically internally
                var invoker = SortLambdaCache.GetOrAdd(typeof(SpecialistDto), key => LambdaExtensions.GetSortLambda<SpecialistDto>().Compile());
                items = invoker(items, options.SortName, options.SortOrder);
                isSorted = true;
            }

            var total = items.Count();

            return new QueryData<SpecialistDto>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems),
                TotalCount = total,
                IsFiltered = isFiltered,
                IsSorted = isSorted,
                IsSearch = isSearched
            };
        }

        public async Task<bool> SaveAsync(SpecialistDto model, ItemChangedType changedType)
        {
            var ret = false;

            if (changedType == ItemChangedType.Add)
            {
                var item = new SpecialistDto()
                {
                    Id = model.Id,
                    TypeDocumentId = model.TypeDocumentId,
                    NumDocument = model.NumDocument,
                    Name = model.Name,
                    LastName = model.LastName,
                    SpecialtyName = model.SpecialtyName,
                    CollegeName = model.CollegeName,
                    CollegeId = model.CollegeId,
                    TypeSexId = model.TypeSexId,
                    Birthdate = model.Birthdate,
                    Address = model.Address,
                    Phone = model.Phone,
                    IsActive = model.IsActive,
                    Editing = model.Editing,
                    IsNew = model.IsNew
                };
                await _specialistService!.AddSpecialist(item);
                Items.Add(item);
            }
            else
            {
                var item = Items.OfType<SpecialistDto>().FirstOrDefault(o => o.Id == model.Id);
                if (item != null)
                {
                    item.TypeDocumentId = model.TypeDocumentId;
                    item.NumDocument = model.NumDocument;
                    item.Name = model.Name;
                    item.LastName = model.LastName;
                    item.SpecialtyName = model.SpecialtyName;
                    item.CollegeName = model.CollegeName;
                    item.CollegeId = model.CollegeId;
                    item.TypeSexId = model.TypeSexId;
                    item.Birthdate = model.Birthdate;
                    item.Address = model.Address;
                    item.Phone = model.Phone;
                    item.IsActive = model.IsActive;
                    item.Editing = model.Editing;
                    item.IsNew = model.IsNew;
                }
                await _specialistService!.UpdateSpecialist(item!);
            }
            ret = true;

            return ret;
        }

        public async Task<bool> DeleteAsync(IEnumerable<SpecialistDto> models)
        {
            var ret = false;
            foreach (var model in models)
            {
                await _specialistService!.DeleteSpecialist(model.Id);
                Items.Remove(model);
            }
            ret = true;

            return ret;
        }
    }
}
