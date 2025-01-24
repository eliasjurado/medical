using Medical.Domain.Dto.Appointment;
using Medical.Domain.Dto.Treatment;

namespace Medical.App.Services.TreatmentService
{
    public interface ITreatmentService
    {
        event Action OnChange;
        List<TreatmentDto> Treatments { get; set; }
        List<TreatmentDto> AdminTreatments { get; set; }
        Task GetTreatments();
        Task<TreatmentDto?> GetTreatmentByName(string name);
        Task GetAdminTreatments();
        Task AddTreatment(TreatmentDto treatment);
        Task UpdateTreatment(TreatmentDto treatment);
        Task DeleteTreatment(int treatmentId);
        TreatmentDto CreateNewTreatment();
    }
}
