using Medical.Domain.Common;

namespace Medical.Domain.Entities;

public class FiscalFamily : BaseAuditableEntity<int>
{
    public string? Code { get; set; }
    public string? SegmentCode { get; set; }
    public string? Name { get; set; }
}
