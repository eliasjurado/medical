namespace Medical.Application.UnitOfWork;

public interface ICommandUnitOfWork<Tkey>
{
    IAppointmentCommandRepository AppointmentCommand { get; }
    ISerieCommandRepository SerieCommand { get; }
    IAppUserCommandRepository AppUserCommand { get; }
    ICategoryCommandRepository CategoryCommand { get; }
    ISubCategoryCommandRepository SubCategoryCommand { get; }
    IClientCommandRepository ClientCommand { get; }
    IPacientCommandRepository PacientCommand { get; }
    ITreatmentCommandRepository TreatmentCommand { get; }
    IWarehouseCommandRepository WarehouseCommand { get; }
    ISpecialistCommandRepository SpecialistCommand { get; }
    IBrandCommandRepository BrandCommand { get; }
    ISaleArticleCommandRepository SaleArticleCommand { get; }
    ISaleCommandRepository SaleCommand { get; }
    IFiscalUnitCommandRepository FiscalUnitCommand { get; }
    IFiscalSegmentCommandRepository FiscalSegmentCommand { get; }
    IFiscalFamilyCommandRepository FiscalFamilyCommand { get; }
    IFiscalClassCommandRepository FiscalClassCommand { get; }
    IFiscalProductCommandRepository FiscalProductCommand { get; }
    IArticleCommandRepository ArticleCommand { get; }
    IArticleStockCommandRepository ArticleStockCommand { get; }

    Task<int> SaveAsync();
}
