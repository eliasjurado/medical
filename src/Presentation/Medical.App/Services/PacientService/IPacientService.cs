using Medical.Domain.Dto.Pacient;

namespace Medical.App.Services.PacientService
{
    public interface IPacientService
    {
        event Action OnChange;
        List<PacientDto> Pacients { get; set; }
        List<PacientDto> AdminPacients { get; set; }
        Task GetPacients();
        Task GetAdminPacients();
        Task AddPacient(PacientDto pacient);
        Task UpdatePacient(PacientDto pacient);
        Task DeletePacient(int pacientId);
        PacientDto CreateNewPacient();
    }
}
