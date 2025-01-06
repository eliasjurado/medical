using Medical.Domain.Dto.Specialist;

namespace Medical.UI.Services.SpecialistService
{
    public interface ISpecialistService
    {
        event Action OnChange;
        List<SpecialistDto> Specialists { get; set; }
        List<SpecialistDto> AdminSpecialists { get; set; }
        Task GetSpecialists();
        Task GetAdminSpecialists();
        Task AddSpecialist(SpecialistDto specialist);
        Task UpdateSpecialist(SpecialistDto specialist);
        Task DeleteSpecialist(int specialistId);
        SpecialistDto CreateNewSpecialist();
    }
}
