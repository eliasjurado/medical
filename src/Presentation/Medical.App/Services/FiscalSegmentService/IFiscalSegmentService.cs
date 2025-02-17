using Medical.Domain.Dto.Fiscal;

namespace Medical.App.Services.FiscalSegmentService;

public interface IFiscalSegmentService
{
    event Action OnChange;
    List<FiscalSegmentDto> FiscalSegments { get; set; }
    List<FiscalSegmentDto> AdminFiscalSegments { get; set; }
    Task GetFiscalSegments();
    Task GetAdminFiscalSegments();
    Task AddFiscalSegment(FiscalSegmentDto item);
    Task UpdateFiscalSegment(FiscalSegmentDto item);
    Task DeleteFiscalSegment(int itemId);
    FiscalSegmentDto CreateNewFiscalSegment();
}
