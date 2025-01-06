using BootstrapBlazor.Components;
using Medical.Domain.Dto.Treatment;
using Medical.UI.Services.TreatmentService;
using Microsoft.AspNetCore.Components;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace Medical.UI.Components.Pages;

public partial class Treatment : ComponentBase
{
    [Inject]
    private ITreatmentService _treatmentService { get; set; }

    private static IEnumerable<int> PageItemsSource => [20, 40];

    [NotNull]
    private List<TreatmentDto>? Items { get; set; }

    private static readonly ConcurrentDictionary<Type, Func<IEnumerable<TreatmentDto>, string, SortOrder, IEnumerable<TreatmentDto>>> SortLambdaCache = new();

    private async Task<QueryData<TreatmentDto>> OnQueryAsync(QueryPageOptions options)
    {
        if (Items == null || !Items.Any())
        {
            await _treatmentService.GetTreatments();
            Items = _treatmentService.Treatments;
        }

        var items = Items;
        var isSearched = false;
        // Handling advanced queries
        if (options.SearchModel is TreatmentDto model)
        {
            if (!string.IsNullOrEmpty(model.Name))
            {
                items = items.Where(item => item.Name?.Contains(model.Name, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
            }

            isSearched = !string.IsNullOrEmpty(model.Name);
        }

        if (options.Searches.Any())
        {
            // Fuzzy search for SearchText
            items = items.Where(options.Searches.GetFilterFunc<TreatmentDto>(FilterLogic.Or)).ToList();
        }

        // Filter
        var isFiltered = false;
        if (options.Filters.Any())
        {
            items = items.Where(options.Filters.GetFilterFunc<TreatmentDto>()).ToList();
            isFiltered = true;
        }

        // Sorting
        var isSorted = false;
        if (!string.IsNullOrEmpty(options.SortName))
        {
            // No sorting is done externally, but sorting is done automatically internally
            var invoker = SortLambdaCache.GetOrAdd(typeof(TreatmentDto), key => LambdaExtensions.GetSortLambda<TreatmentDto>().Compile());
            items = invoker(items, options.SortName, options.SortOrder).ToList();
            isSorted = true;
        }

        var total = items.Count();

        return new QueryData<TreatmentDto>()
        {
            Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
            TotalCount = total,
            IsFiltered = isFiltered,
            IsSorted = isSorted,
            IsSearch = isSearched
        };
    }

    public Task<bool> SaveAsync(TreatmentDto model, ItemChangedType changedType)
    {
        var ret = false;

        if (changedType == ItemChangedType.Add)
        {
            var item = new TreatmentDto()
            {
                Id = model.Id,
                Name = model.Name,
                DurationMinutes = model.DurationMinutes,
                IsActive = model.IsActive,
                Editing = model.Editing,
                IsNew = model.IsNew
            };
            _treatmentService.AddTreatment(item);
            Items.Add(item);
        }
        else
        {
            var item = Items.OfType<TreatmentDto>().FirstOrDefault(o => o.Id == model.Id);
            if (item != null)
            {
                item.Name = model.Name;
                item.DurationMinutes = model.DurationMinutes;
                item.IsActive = model.IsActive;
                item.Editing = model.Editing;
                item.IsNew = model.IsNew;
            }
            _treatmentService.UpdateTreatment(item);
        }
        ret = true;

        return Task.FromResult(ret);
    }

    public Task<bool> DeleteAsync(IEnumerable<TreatmentDto> models)
    {
        var ret = false;
        foreach (var model in models)
        {
            _treatmentService.DeleteTreatment(model.Id);
            Items.Remove(model);
        }
        ret = true;

        return Task.FromResult(ret);
    }

}
