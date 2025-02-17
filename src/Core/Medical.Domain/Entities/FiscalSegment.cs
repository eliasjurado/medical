using Medical.Domain.Common;

namespace Medical.Domain.Entities;

public class FiscalSegment : BaseAuditableEntity<int>
{
    public string? Code { get; set; }
    public string? Name { get; set; }
}
