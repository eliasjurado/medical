namespace Medical.Application.UnitOfWork;

public interface ICommandUnitOfWork<Tkey>
{
    IAppointmentCommandRepository AppointmentCommand { get; }
    ICategoryCommandRepository CategoryCommand { get; }
    IPacientCommandRepository PacientCommand { get; }
    ITreatmentCommandRepository TreatmentCommand { get; }
    ISpecialistCommandRepository SpecialistCommand { get; }
    IBrandCommandRepository BrandCommand { get; }
    IFiscalUnitCommandRepository FiscalUnitCommand { get; }
    IFiscalSegmentCommandRepository FiscalSegmentCommand { get; }
    IFiscalFamilyCommandRepository FiscalFamilyCommand { get; }
    IFiscalClassCommandRepository FiscalClassCommand { get; }
    IFiscalProductCommandRepository FiscalProductCommand { get; }
    IArticleCommandRepository ArticleCommand { get; }

    Task<int> SaveAsync();
}
