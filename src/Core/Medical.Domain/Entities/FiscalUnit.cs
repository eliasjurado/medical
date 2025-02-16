using Medical.Domain.Common;

namespace Medical.Domain.Entities;

public class FiscalUnit : BaseAuditableEntity<int>
{
    public string? Code { get; set; }
    public string? Name { get; set; }
}
