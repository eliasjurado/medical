using BootstrapBlazor.Components;
using Medical.Domain.Dto.Pacient;
using Medical.UI.Services.PacientService;
using Microsoft.AspNetCore.Components;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace Medical.UI.Components.Pages
{
    public partial class Pacient : ComponentBase
    {
        private static IEnumerable<int> PageItemsSource => [20, 40];

        [Inject]
        private IPacientService _pacientService { get; set; }

        [NotNull]
        private List<PacientDto>? Items { get; set; }

        private static readonly ConcurrentDictionary<Type, Func<IEnumerable<PacientDto>, string, SortOrder, IEnumerable<PacientDto>>> SortLambdaCache = new();

        public async Task<QueryData<PacientDto>> OnQueryAsync(QueryPageOptions options)
        {
            // The code here is not available in actual combat. It is written only for demonstration to prevent all data from being deleted.
            if (Items == null || Items.Count == 0)
            {
                await _pacientService.GetPacients();
                Items = _pacientService.Pacients;
            }

            var items = Items.AsEnumerable();
            var isSearched = false;
            // Handling advanced queries
            if (options.SearchModel is PacientDto model)
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

                if (!string.IsNullOrEmpty(model.Address))
                {
                    items = items.Where(item => item.Address?.Contains(model.Address, StringComparison.OrdinalIgnoreCase) ?? false);
                }

                if (!string.IsNullOrEmpty(model.Phone))
                {
                    items = items.Where(item => item.Phone?.Contains(model.Phone, StringComparison.OrdinalIgnoreCase) ?? false);
                }

                isSearched = !string.IsNullOrEmpty(model.NumDocument) || !string.IsNullOrEmpty(model.Name) || !string.IsNullOrEmpty(model.LastName) || !string.IsNullOrEmpty(model.Address) || !string.IsNullOrEmpty(model.Phone);
            }

            if (options.Searches.Count != 0)
            {
                // Fuzzy search for SearchText
                items = items.Where(options.Searches.GetFilterFunc<PacientDto>(FilterLogic.Or));
            }

            // Filter
            var isFiltered = false;
            if (options.Filters.Count != 0)
            {
                items = items.Where(options.Filters.GetFilterFunc<PacientDto>());
                isFiltered = true;
            }

            // Sorting
            var isSorted = false;
            if (!string.IsNullOrEmpty(options.SortName))
            {
                // No sorting is done externally, but sorting is done automatically internally
                var invoker = SortLambdaCache.GetOrAdd(typeof(PacientDto), key => LambdaExtensions.GetSortLambda<PacientDto>().Compile());
                items = invoker(items, options.SortName, options.SortOrder);
                isSorted = true;
            }

            var total = items.Count();

            return new QueryData<PacientDto>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems),
                TotalCount = total,
                IsFiltered = isFiltered,
                IsSorted = isSorted,
                IsSearch = isSearched
            };
        }

        public async Task<bool> SaveAsync(PacientDto model, ItemChangedType changedType)
        {
            var ret = false;

            if (changedType == ItemChangedType.Add)
            {
                var item = new PacientDto()
                {
                    Id = model.Id,
                    TypeDocumentId = model.TypeDocumentId,
                    NumDocument = model.NumDocument,
                    Name = model.Name,
                    LastName = model.LastName,
                    TypeSexId = model.TypeSexId,
                    Birthdate = model.Birthdate,
                    Address = model.Address,
                    Phone = model.Phone,
                    IsActive = model.IsActive,
                    Editing = model.Editing,
                    IsNew = model.IsNew
                };
                await _pacientService.AddPacient(item);
                Items.Add(item);
            }
            else
            {
                var item = Items.OfType<PacientDto>().FirstOrDefault(o => o.Id == model.Id);
                if (item != null)
                {
                    item.TypeDocumentId = model.TypeDocumentId;
                    item.NumDocument = model.NumDocument;
                    item.Name = model.Name;
                    item.LastName = model.LastName;
                    item.TypeSexId = model.TypeSexId;
                    item.Birthdate = model.Birthdate;
                    item.Address = model.Address;
                    item.Phone = model.Phone;
                    item.IsActive = model.IsActive;
                    item.Editing = model.Editing;
                    item.IsNew = model.IsNew;
                }
                await _pacientService.UpdatePacient(item);
            }
            ret = true;

            return ret;
        }

        public async Task<bool> DeleteAsync(IEnumerable<PacientDto> models)
        {
            var ret = false;
            foreach (var model in models)
            {
                await _pacientService.DeletePacient(model.Id);
                Items.Remove(model);
            }
            ret = true;

            return ret;
        }
    }
}
