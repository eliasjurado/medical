using BootstrapBlazor.Components;
using Medical.Domain.Dto.Appointment;
using Medical.UI.Services.AppointmentService;
using Microsoft.AspNetCore.Components;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace Medical.UI.Components.Pages
{
    public partial class Appointment : ComponentBase
    {
        private static IEnumerable<int> PageItemsSource => [20, 40];

        [Inject]
        private IAppointmentService? _appointmentService { get; set; }

        [NotNull]
        private List<AppointmentDto>? Items { get; set; }

        private static readonly ConcurrentDictionary<Type, Func<IEnumerable<AppointmentDto>, string, SortOrder, IEnumerable<AppointmentDto>>> SortLambdaCache = new();

        public async Task<QueryData<AppointmentDto>> OnQueryAsync(QueryPageOptions options)
        {
            // The code here is not available in actual combat. It is written only for demonstration to prevent all data from being deleted.
            if (Items == null || Items.Count == 0)
            {
                await _appointmentService!.GetAppointments();
                Items = _appointmentService.Appointments;
            }

            var items = Items.AsEnumerable();
            var isSearched = false;
            // Handling advanced queries
            if (options.SearchModel is AppointmentDto model)
            {
                if (!string.IsNullOrEmpty(model.Pacient.Name))
                {
                    items = items.Where(item => item.Pacient.Name?.Contains(model.Pacient.Name, StringComparison.OrdinalIgnoreCase) ?? false);
                }

                if (!string.IsNullOrEmpty(model.Pacient.LastName))
                {
                    items = items.Where(item => item.Pacient.LastName?.Contains(model.Pacient.LastName, StringComparison.OrdinalIgnoreCase) ?? false);
                }

                if (!string.IsNullOrEmpty(model.Treatment.Name))
                {
                    items = items.Where(item => item.Treatment.Name?.Contains(model.Treatment.Name, StringComparison.OrdinalIgnoreCase) ?? false);
                }

                if (!string.IsNullOrEmpty(model.Specialist!.Name))
                {
                    items = items.Where(item => item.Specialist!.Name?.Contains(model.Specialist.Name, StringComparison.OrdinalIgnoreCase) ?? false);
                }

                if (!string.IsNullOrEmpty(model.Specialist!.LastName))
                {
                    items = items.Where(item => item.Specialist!.LastName?.Contains(model.Specialist.LastName, StringComparison.OrdinalIgnoreCase) ?? false);
                }

                isSearched = !string.IsNullOrEmpty(model.Pacient.Name) || !string.IsNullOrEmpty(model.Pacient.LastName) || !string.IsNullOrEmpty(model.Treatment.Name) || !string.IsNullOrEmpty(model.Specialist!.Name) || !string.IsNullOrEmpty(model.Specialist!.LastName);
            }

            if (options.Searches.Count != 0)
            {
                // Fuzzy search for SearchText
                items = items.Where(options.Searches.GetFilterFunc<AppointmentDto>(FilterLogic.Or));
            }

            // Filter
            var isFiltered = false;
            if (options.Filters.Count != 0)
            {
                items = items.Where(options.Filters.GetFilterFunc<AppointmentDto>());
                isFiltered = true;
            }

            // Sorting
            var isSorted = false;
            if (!string.IsNullOrEmpty(options.SortName))
            {
                // No sorting is done externally, but sorting is done automatically internally
                var invoker = SortLambdaCache.GetOrAdd(typeof(AppointmentDto), key => LambdaExtensions.GetSortLambda<AppointmentDto>().Compile());
                items = invoker(items, options.SortName, options.SortOrder);
                isSorted = true;
            }

            var total = items.Count();

            return new QueryData<AppointmentDto>()
            {
                Items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems),
                TotalCount = total,
                IsFiltered = isFiltered,
                IsSorted = isSorted,
                IsSearch = isSearched
            };
        }

        public async Task<bool> SaveAsync(AppointmentDto model, ItemChangedType changedType)
        {
            var ret = false;

            if (changedType == ItemChangedType.Add)
            {
                var item = new AppointmentDto()
                {
                    Id = model.Id,
                    IdPacient = model.IdPacient,
                    IdTreatment = model.IdTreatment,
                    IdSpecialist = model.IdSpecialist,
                    StartDateTime = model.StartDateTime,
                    EndDateTime = model.EndDateTime,
                    Note = model.Note,
                    TypeShiftId = model.TypeShiftId,
                    TypeAppointmentId = model.TypeAppointmentId,
                    IsActive = model.IsActive,
                    Editing = model.Editing,
                    IsNew = model.IsNew
                };
                await _appointmentService!.AddAppointment(item);
                Items.Add(item);
            }
            else
            {
                var item = Items.OfType<AppointmentDto>().FirstOrDefault(o => o.Id == model.Id);
                if (item != null)
                {
                    item.IdPacient = model.IdPacient;
                    item.IdTreatment = model.IdTreatment;
                    item.IdSpecialist = model.IdSpecialist;
                    item.StartDateTime = model.StartDateTime;
                    item.EndDateTime = model.EndDateTime;
                    item.Note = model.Note;
                    item.TypeShiftId = model.TypeShiftId;
                    item.TypeAppointmentId = model.TypeAppointmentId;
                    item.IsActive = model.IsActive;
                    item.Editing = model.Editing;
                    item.IsNew = model.IsNew;
                }
                await _appointmentService!.UpdateAppointment(item!);
            }
            ret = true;

            return ret;
        }

        public async Task<bool> DeleteAsync(IEnumerable<AppointmentDto> models)
        {
            var ret = false;
            foreach (var model in models)
            {
                await _appointmentService!.DeleteAppointment(model.Id);
                Items.Remove(model);
            }
            ret = true;

            return ret;
        }
    }
}
