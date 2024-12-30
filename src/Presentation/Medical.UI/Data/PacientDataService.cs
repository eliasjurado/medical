using BootstrapBlazor.Components;
using Medical.Domain.Dto.Pacient;
using Medical.UI.Services.PacientService;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace Medical.UI.Data
{

    /// <summary>
    /// Data injection service implementation class
    /// </summary>
    public class PacientDataService<T> : DataServiceBase<T> where T : class, new()
    {
        private static readonly ConcurrentDictionary<Type, Func<IEnumerable<T>, string, SortOrder, IEnumerable<T>>> SortLambdaCache = new();

        [NotNull]
        private List<T>? Items { get; set; }

        private IPacientService _pacientService { get; set; }

        public PacientDataService(IPacientService pacientService)
        {
            _pacientService = pacientService;
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
                await _pacientService.GetPacients();
                var x = _pacientService.Pacients;
                var y = JsonConvert.SerializeObject(x);
                var z = JsonConvert.DeserializeObject<List<T>>(y);
                Items = z;
            }

            var items = Items.AsEnumerable();
            var isSearched = false;
            // Handling advanced queries
            if (options.SearchModel is PacientDto model)
            {
                if (!string.IsNullOrEmpty(model.NumDocument))
                {
                    items = items.Cast<PacientDto>().Where(item => item.NumDocument?.Contains(model.NumDocument, StringComparison.OrdinalIgnoreCase) ?? false).Cast<T>();
                }

                if (!string.IsNullOrEmpty(model.Name))
                {
                    items = items.Cast<PacientDto>().Where(item => item.Name?.Contains(model.Name, StringComparison.OrdinalIgnoreCase) ?? false).Cast<T>();
                }

                if (!string.IsNullOrEmpty(model.LastName))
                {
                    items = items.Cast<PacientDto>().Where(item => item.LastName?.Contains(model.LastName, StringComparison.OrdinalIgnoreCase) ?? false).Cast<T>();
                }

                if (!string.IsNullOrEmpty(model.Address))
                {
                    items = items.Cast<PacientDto>().Where(item => item.Address?.Contains(model.Address, StringComparison.OrdinalIgnoreCase) ?? false).Cast<T>();
                }

                if (!string.IsNullOrEmpty(model.Phone))
                {
                    items = items.Cast<PacientDto>().Where(item => item.Phone?.Contains(model.Phone, StringComparison.OrdinalIgnoreCase) ?? false).Cast<T>();
                }

                isSearched = !string.IsNullOrEmpty(model.NumDocument) || !string.IsNullOrEmpty(model.Name) || !string.IsNullOrEmpty(model.LastName) || !string.IsNullOrEmpty(model.Address) || !string.IsNullOrEmpty(model.Phone);
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
                var invoker = SortLambdaCache.GetOrAdd(typeof(PacientDto), key => LambdaExtensions.GetSortLambda<T>().Compile());
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
            if (model is PacientDto i)
            {
                if (changedType == ItemChangedType.Add)
                {
                    var item = new PacientDto()
                    {
                        Id = i.Id,
                        TypeDocument = i.TypeDocument,
                        NumDocument = i.NumDocument,
                        Name = i.Name,
                        LastName = i.LastName,
                        TypeSex = i.TypeSex,
                        Birthdate = i.Birthdate,
                        Address = i.Address,
                        Phone = i.Phone,
                        IsActive = i.IsActive,
                        Editing = i.Editing,
                        IsNew = i.IsNew
                    };
                    await _pacientService.AddPacient(item);
                    Items.Add(item! as T);
                }
                else
                {
                    var o = Items.OfType<PacientDto>().FirstOrDefault(s => s.Id == i.Id);
                    if (o != null)
                    {
                        o.TypeDocument = i.TypeDocument;
                        o.NumDocument = i.NumDocument;
                        o.Name = i.Name;
                        o.LastName = i.LastName;
                        o.TypeSex = i.TypeSex;
                        o.Birthdate = i.Birthdate;
                        o.Address = i.Address;
                        o.Phone = i.Phone;
                        o.IsActive = i.IsActive;
                        o.Editing = i.Editing;
                        o.IsNew = i.IsNew;
                    }
                    await _pacientService.UpdatePacient(o);
                }
                ret = true;
            }
            return ret;
        }

        public async override Task<bool> DeleteAsync(IEnumerable<T> models)
        {
            foreach (var model in models)
            {
                if (model is PacientDto i)
                {
                    await _pacientService.DeletePacient(i.Id);
                }
                Items.Remove(model);
            }

            return await base.DeleteAsync(models);
        }
    }
}
