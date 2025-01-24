using Medical.Domain.Dto.Specialist;
using Medical.Domain.Dto.Treatment;

namespace Medical.App.Services.SpecialistService
{
    public interface ISpecialistService
    {
        event Action OnChange;
        List<SpecialistDto> Specialists { get; set; }
        List<SpecialistDto> AdminSpecialists { get; set; }
        Task GetSpecialists();
        Task<SpecialistDto?> GetSpecialistByFullName(string fullName);
        Task GetAdminSpecialists();
        Task AddSpecialist(SpecialistDto specialist);
        Task UpdateSpecialist(SpecialistDto specialist);
        Task DeleteSpecialist(int specialistId);
        SpecialistDto CreateNewSpecialist();
    }
}
